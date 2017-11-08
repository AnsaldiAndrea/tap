using System;
using EmailSenderInterfaces;

namespace EmailSenderImplementation2
{
    public class EmailSenderImplementationTwo : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Send from Implementation 2");
            Console.WriteLine("To: " + to);
            Console.WriteLine(body);
            return true;
        }
    }
}
