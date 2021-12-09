using NLog;

namespace LoggerLayer
{
    public class ApplicationBase
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    }

}
