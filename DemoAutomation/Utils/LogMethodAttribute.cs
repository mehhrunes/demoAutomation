using System;
using System.Reflection;
using DemoAutomation.Utils;
using MethodDecorator.Fody.Interfaces;
using Serilog;

[module: LogMethod]

namespace DemoAutomation.Utils
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly |
                    AttributeTargets.Module)]
    public class LogMethodAttribute : Attribute, IMethodDecorator
    {
        private MethodBase _method;

        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;
        }

        public void OnEntry()
        {
            Log.Debug($"Entering {_method.Name}");
        }

        public void OnExit()
        {
            Log.Debug($"Exiting {_method.Name}");
        }

        public void OnException(Exception exception)
        {
            Log.Debug($"Exception occured in {_method.Name} : {exception}");
        }
    }
}