using System;
using MyAttribute;

namespace MyLibrary
{
    public class Pippo
    {
        [ExecuteMe]
        public void F1()
        {
            Console.WriteLine("F1");
        }

        [ExecuteMe(12.4)]
        [ExecuteMe(0.3)]
        public void F2(double a)
        {
            Console.WriteLine("F2 a={0}", a);
        }

        [ExecuteMe("answer", 42)]
        [ExecuteMe("test", 13)]
        public void F3(string s1, int i2)
        {
            Console.WriteLine("F3 s1={0} i2={1}", s1, i2);
        }
    }
}
