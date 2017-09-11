using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServiceTeste.Jobs
{
    public class IncluirFreteMedioMISJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new IncluirFreteMedioMIS().Execute();
        }
    }
}
