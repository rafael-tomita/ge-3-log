using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectConsole02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Início.");

            FazerCoisas();

            Console.WriteLine("Fim.");
            Console.ReadKey();
        }

        private static void FazerCoisas()
        {
            var a = new UmaCoisa().ComLog();

            a.Fazer();

            var b = new OutraCoisa().ComLog();

            b.Fazer(2, 4);
        }
    }
}
