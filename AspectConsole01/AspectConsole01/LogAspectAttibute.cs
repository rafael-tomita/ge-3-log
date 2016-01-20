using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace AspectConsole01
{
    [Serializable]
    public class LogAspectAttibute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Entrou no método {0}.{1}. Argumentos: {2}",
                args.Method.DeclaringType.Name,
                args.Method.Name,
                args.Arguments.Count);
        }
    }
}
