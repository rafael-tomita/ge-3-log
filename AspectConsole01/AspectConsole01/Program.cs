using System;

namespace AspectConsole01
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
            var a = new UmaCoisa();
            a.Fazer();

            var b = new OutraCoisa();
            b.Fazer(2, 4);
        }
    }
}
