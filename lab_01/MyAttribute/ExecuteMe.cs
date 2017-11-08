using System;

namespace MyAttribute
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMe : Attribute
    {
        private readonly object[] _arguments;

        public ExecuteMe(params object[] arguments)
        {
            this._arguments = arguments;
        }

        public object[] GetArguments()
        {
            return this._arguments;
        }

    }
}
