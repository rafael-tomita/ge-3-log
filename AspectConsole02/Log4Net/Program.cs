using System;
using log4net;
using log4net.Core;

namespace Log4Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            var log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (log.IsDebugEnabled)
            {
                log.Debug("Application loaded successfully.");
            }

            for (var i = 0; i < 100000; i++)
            {
                log.Error(i + "teste2");
            }

            var Conta = new Somar();
            var result = Conta.SomarAb(10, 12);
        }
    }
}
