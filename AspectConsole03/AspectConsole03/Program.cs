using System;

namespace AspectConsole03
{
    public static class Program
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

            var retorno = b.Fazer(2, 4);

            Console.WriteLine("Retorno da outra coisa: {0}", retorno);
        }
    }
}
