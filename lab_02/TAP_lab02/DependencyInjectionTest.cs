
using System;
using EmailSenderInterfaces;
using TinyDependencyInjectionContainer;

namespace TAP_lab02
{
    public class DependencyInjectionTest
    {
        public static void Main(string[] args)
        {
            var resolver = new InterfaceResolver("../../../Config.txt");
            var sender = resolver.Instantiate<IEmailSender>();
            sender.SendEmail("sender", "message to send");
            Console.ReadLine();
        }
    }
}
