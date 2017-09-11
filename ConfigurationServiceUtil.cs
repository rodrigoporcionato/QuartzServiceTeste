using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServiceTeste
{
   public class ConfigurationServiceUtil
   {


        public static int HoraInicioExecucaoServico
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["HoraInicioExecucaoServico"] ?? "00");
            }
            private set { }
        }

        public static int MinutoInicioExecucaoServico
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["MinutoInicioExecucaoServico"] ?? "00");
            }
            private set { }
        }


        public static string ServiceName
        {
            get
            {
                return ConfigurationManager.AppSettings["InstanceFactory"];
            }
            private set { }
        }

        

        public static bool EnableLogEvent
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["EnableLogEvent"] ?? "true");
            }
            private set { }
        }

        public static double Interval
        {
            get
            {
                return double.Parse(ConfigurationManager.AppSettings["TimerInterval"] ?? "1800000");
            }
            private set { }
        }

    }
}
