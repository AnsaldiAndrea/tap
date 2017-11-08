using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly Dictionary<Type, Type> _injectionDictionary = new Dictionary<Type, Type>();

        public InterfaceResolver(string pathName)
        {
            try
            {
                var lines = File.ReadAllLines(pathName);
                foreach (var line in lines)
                {
                    if (line.StartsWith("#")) continue;
                    var dataNames = line.Split('*');
                    var interfaceDll = dataNames[0];
                    var interfaceClass = dataNames[1];
                    var implementationDll = dataNames[2];
                    var implementationClass = dataNames[3];

                    var interfaceAssembly = Assembly.LoadFrom(interfaceDll);
                    var interfaceType = interfaceAssembly.GetType(interfaceClass);
                    var implementaioneAssemblyt = Assembly.LoadFrom(implementationDll);
                    var implementationType = implementaioneAssemblyt.GetType(implementationClass);

                    //if(!interfaceType.IsInterface) continue;
                    //if(!implementationType.IsSubclassOf(interfaceType)) continue;

                    _injectionDictionary.Add(interfaceType, implementationType);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Config file has incorrect format");
            }
            catch (FileNotFoundException file)
            {
                Console.WriteLine($"File: \"{file.FileName}\" does not exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Instantiate<T>() where T : class
        {
            try
            {
                if (!_injectionDictionary.ContainsKey(typeof(T))) return null;
                var instanceType = _injectionDictionary[typeof(T)];
                return (T) Activator.CreateInstance(instanceType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
