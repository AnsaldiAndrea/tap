using System;
using System.Linq;
using System.Reflection;
using MyAttribute;

namespace Executer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in a.GetTypes())
            {
                if (!type.IsClass) continue;
                foreach (var method in type.GetMethods())
                {
                    var attributes = method.GetCustomAttributes<ExecuteMe>(false);
                    if (!attributes.Any()) continue;
                    Console.WriteLine(method.Name);
                    var instance = Activator.CreateInstance(type);
                    foreach (var attr in attributes)
                    {
                        method.Invoke(instance, attr.GetArguments());
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
