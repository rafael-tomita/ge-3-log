using System;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace AspectConsole03
{
    [Serializable]
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var classe = invocation.Method.DeclaringType?.Name;
            var metodo = invocation.Method.Name;
            var argumentos = invocation.Arguments.Length;

            Console.WriteLine();
            Log("Entrou no método '{0}.{1}'. Argumentos: {2}", classe, metodo, argumentos);

            try
            {
                invocation.Proceed();

                var retorno = invocation.Method.ReturnType == typeof(void) ? "void" : invocation.ReturnValue;

                Log("Saiu do método '{0}.{1}'. Retorno: {2}.", classe, metodo, retorno ?? "null");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Log("Na execução de '{0}.{1}' deu o seguinte pau:\n{2}.", classe, metodo, ex);
            }
        }

        private static void Log(string msg, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}: ", DateTime.Now);
            Console.WriteLine(msg, args);
            Console.ResetColor();
        }
    }

    public static class Extensions
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static T ComLog<T>(this T o) where T : class, new()
        {
            var proxy = Generator.CreateClassProxy<T>(new LogInterceptor());

            return proxy;
        }
    }

}
