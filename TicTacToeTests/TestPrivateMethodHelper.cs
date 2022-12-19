using System;
using System.Reflection;

namespace TicTacToeTests
{
    public class TestPrivateMethodHelper
    {
        private readonly object _obj;

        public TestPrivateMethodHelper(object obj)
        {
            this._obj = obj;
        }

        public object? Invoke(string methodName, params object[] args)
        {
            var methodInfo = _obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo is null)
            {
                throw new Exception($"Method name {methodName} not found in {_obj.GetType()}");
            }

            return methodInfo.Invoke(_obj, args);
        }
    }
}
