using log4net;

namespace Log4NetProject
{
    public class Logger
    {
        private static ILog log;

        public static void Log(string texto, params object[] args)
        {
            log = LogManager.GetLogger(args[0].ToString());
            log.DebugFormat(texto,args);
        }
    }
}
