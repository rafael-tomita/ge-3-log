using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using PostSharp.Aspects;

namespace AspectConsole01
{
    [Serializable]
    public class LogAspectAttibute : OnMethodBoundaryAspect
    {
        private static void Log(string texto, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(texto, args);
            Console.ResetColor();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!EhParaGerarLogDisso(args))
                return;

            Console.WriteLine();

            Log("Entrou no método \"{0}.{1}\"; Argumentos: {2};",
                args.Method.DeclaringType?.Name,
                args.Method.Name,
                args.Arguments.Count);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            if (!EhParaGerarLogDisso(args))
                return;

            Log("Saiu do método \"{0}.{1}\"; Retorno: {2};",
                args.Method.DeclaringType?.Name,
                args.Method.Name,
                (Type)args.Method.GetType().GetProperty("ReturnType").GetValue(args.Method) == typeof(void) ? "void" : args.ReturnValue?.ToString() ?? "null");
            Console.WriteLine();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Log("Exceção no método \"{0}.{1}\": {2};",
                args.Method.DeclaringType?.Name,
                args.Method.Name,
                args.Exception);
            Console.ReadKey();
        }

        private static bool EhParaGerarLogDisso(MethodExecutionArgs args)
        {
            return !args.Method.IsConstructor;
        }
    }
}
