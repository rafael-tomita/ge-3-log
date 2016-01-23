using System;

namespace AspectConsole03
{
    public class UmaCoisa
    {
        public virtual void Fazer()
        {
            Console.WriteLine("Fazendo uma coisa.");
        }
    }

    public class OutraCoisa
    {
        public virtual int? Fazer(int a, int b)
        {
            Console.WriteLine("Fazendo outra coisa: {0}, {1};", a, b);

            var a1 = new MaisUmaCoisa().ComLog().Fazer(a);

            //throw new Exception("Deu pau aqui na outra coisa."); //HACK: Comentar ou descomentar para testar.

            var a2 = new MaisUmaCoisa().ComLog().Fazer(b);

            Console.WriteLine("Soma das coisa feitas: {0}. Retornarei nulo.", a1 + a2);

            return null;
        }
    }

    public class MaisUmaCoisa
    {
        public virtual int Fazer(int parametro1)
        {
            Console.WriteLine("Fazendo mais uma coisa. Retornarei o parametro {0} * 2;", parametro1);
            return parametro1 * 2;
        }
    }
}
