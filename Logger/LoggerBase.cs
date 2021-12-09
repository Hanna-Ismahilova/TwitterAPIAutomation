using NLog;

namespace LoggerLayer
{
    public class LoggerBase
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    }

}
