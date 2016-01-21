using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace AspectConsole02
{
    class DynamicProxy : RealProxy
    {
        private readonly object decorated;

        public DynamicProxy(object decorated) : base(decorated.GetType())
        {
            this.decorated = decorated;
        }

        private static void Log(string msg, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}: ", DateTime.Now);
            Console.WriteLine(msg, args);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            if (methodCall == null)
                throw new ArgumentException("O-oh... msg não pôde ser convertido em IMethodCallMessage.");

            Console.WriteLine();
            Log("Entrou no método '{0}.{1}'. Argumentos: {2}", methodCall.MethodBase.DeclaringType?.Name, methodCall.MethodName, methodCall.ArgCount);

            var methodInfo = methodCall.MethodBase as MethodInfo;
            if (methodInfo == null)
                throw new ArgumentException("O-oh... msg.MethodBase não pôde ser convertido em MethodInfo.");

            try
            {
                var result = methodInfo.Invoke(decorated, methodCall.InArgs);
                Log("Saiu do método '{0}.{1}'.", methodCall.MethodBase.DeclaringType?.Name, methodCall.MethodName);
                Console.WriteLine();

                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log("Na execução de '{0}.{1}' deu o seguinte pau:\n{2}.", methodCall.MethodBase.DeclaringType?.Name, methodCall.MethodName, e);

                return new ReturnMessage(e, methodCall);
            }
        }
    }

    public static class Util
    {
        public static T ComLog<T>(this T target) where T : MarshalByRefObject
        {
            return (T)new DynamicProxy(target).GetTransparentProxy();
        }
    }
}
