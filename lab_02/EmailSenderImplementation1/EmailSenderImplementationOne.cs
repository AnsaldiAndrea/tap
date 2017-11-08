using System;
using EmailSenderInterfaces;

namespace EmailSenderImplementation1
{
    public class EmailSenderImplementationOne:IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Send from Implementation 1");
            Console.WriteLine("To: " + to);
            Console.WriteLine(body);
            return true;
        }
    }
}
