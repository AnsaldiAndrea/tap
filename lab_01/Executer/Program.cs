using System;
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
                var className = type.FullName;
                try
                {
                    var instance = Activator.CreateInstance(type);
                    foreach (var method in type.GetMethods())
                    {
                        var methodName = $"{className}.{method.Name}";
                        var attributes = method.GetCustomAttributes<ExecuteMe>(false);
                        foreach (var attr in attributes)
                        {
                            try
                            {
                                method.Invoke(instance, attr.GetArguments());
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("Impossibile esegure il metodo {0} perchè il uno o più paramentri forniti sono di tipo sbagliato", methodName);
                            }
                            catch (TargetParameterCountException)
                            {
                                Console.WriteLine("Impossibile esegure il metodo {0} perchè il numero di parametri fornito è sbagliate", methodName);
                            }
                        }
                    }
                }
                catch (MissingMethodException)
                {
                    Console.WriteLine("Inpossibile instanziare la classe {0} perchè non implementa il costruttore di default",className);
                }
            }
            Console.ReadLine();
        }
    }
}
