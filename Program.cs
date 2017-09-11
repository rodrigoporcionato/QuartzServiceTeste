using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServiceTeste
{
    static class Program
    {       
        static void Main()
        {
            string chave = ConfigurationServiceUtil.ServiceName;

            if (Environment.UserInteractive && Debugger.IsAttached)
            {
                switch (chave)
                {
                    case "IncluirFreteMedioMIS":
                        new IncluirFreteMedioMIS().Execute();
                        return;
                    case "ExportarParcelamentoMIS":
                        new ExportarParcelamentoMIS().Execute();
                        return;
                    default:
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    Program.ConcreteFactory(chave)
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        public static ServiceBase ConcreteFactory(string chave)
        {
            switch (chave)
            {
                case "IncluirFreteMedioMIS":
                    return new IncluirFreteMedioMIS();
                case "ExportarParcelamentoMIS":
                    return new ExportarParcelamentoMIS();
                default:
                    throw new NotImplementedException();
            }
        }






    }
}
