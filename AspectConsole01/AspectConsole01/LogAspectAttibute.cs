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
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!EhParaGerarLogDisso(args))
                return;

            Console.WriteLine();

            Console.WriteLine("Entrou no método \"{0}.{1}\"; Argumentos: {2};",
                args.Method.DeclaringType?.Name,
                args.Method.Name,
                args.Arguments.Count);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            if (!EhParaGerarLogDisso(args))
                return;

            Console.WriteLine("Saiu do método \"{0}.{1}\"; Retorno: {2};",
                args.Method.DeclaringType?.Name,
                args.Method.Name,
                args.Method.GetType().GetProperty("ReturnType").GetValue(args.Method) == typeof(void) ? "void" : args.ReturnValue?.ToString() ?? "null");

            Console.WriteLine();
        }

        private static bool EhParaGerarLogDisso(MethodExecutionArgs args)
        {
            return args.Method.Name != ".ctor";
        }
    }
}
