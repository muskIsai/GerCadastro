using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;

namespace CadaManage
{
    public class Logger
    {
        private static readonly ILog logger = LogManager.GetLogger("MyLogger");

        public static ILog Log
        {
            get { return logger; }
        }
        public static void Init()
        {
            XmlConfigurator.Configure();
            logger.Info("Logger Init...");
        }
    }
}