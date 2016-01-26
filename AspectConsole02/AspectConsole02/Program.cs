using System;
using log4net;

namespace AspectConsole02
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

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
