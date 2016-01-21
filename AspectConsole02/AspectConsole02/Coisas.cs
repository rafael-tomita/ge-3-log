using System;

namespace AspectConsole02
{
    public class UmaCoisa : MarshalByRefObject
    {
        public void Fazer()
        {
            Console.WriteLine("Fazendo uma coisa.");
        }
    }

    public class OutraCoisa : MarshalByRefObject
    {
        public int? Fazer(int a, int b)
        {
            //try
            //{
            Console.WriteLine("Fazendo outra coisa: {0}, {1};", a, b);

            var a1 = new MaisUmaCoisa().ComLog().Fazer(a);

            //throw new Exception("Deu pau aqui."); //HACK: Comentar ou descomentar para testar.

            var a2 = new MaisUmaCoisa().ComLog().Fazer(b);

            Console.WriteLine("Soma das coisa feitas: {0}", a1 + a2);
            //}
            //catch
            //{

            //}

            return null;
        }
    }

    public class MaisUmaCoisa : MarshalByRefObject
    {
        public int Fazer(int parametro1)
        {
            Console.WriteLine("Fazendo mais uma coisa: {0};", parametro1);
            return parametro1 * 2;
        }
    }
}
