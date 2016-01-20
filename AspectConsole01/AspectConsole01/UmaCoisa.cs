using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AspectConsole01
{
    [LogAspectAttibute]
    public class UmaCoisa
    {
        public void Fazer()
        {
            Console.WriteLine("Fazendo uma coisa.");
        }
    }

    [LogAspectAttibute]
    public class OutraCoisa
    {
        public int? Fazer(int a, int b)
        {
            //try
            //{
                Console.WriteLine("Fazendo outra coisa: {0}, {1};", a, b);

                var a1 = new MaisUmaCoisa().Fazer(a);

                //throw new Exception("Deu pau aqui."); //HACK: Comentar ou descomentar para testar.

                var a2 = new MaisUmaCoisa().Fazer(b);

                Console.WriteLine("Soma das coisa feitas: {0}", a1 + a2);
            //}
            //catch
            //{

            //}

            return null;
        }
    }

    [LogAspectAttibute]
    public class MaisUmaCoisa
    {
        public int Fazer(int parametro1)
        {
            Console.WriteLine("Fazendo mais uma coisa: {0};", parametro1);
            return parametro1 * 2;
        }
    }
}
