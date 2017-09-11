using Quartz;
using Quartz.Impl;
using QuartzServiceTeste.Jobs;
using System.Diagnostics;
using System.Threading;

namespace QuartzServiceTeste
{
    partial class IncluirFreteMedioMIS : CustomService
    {
        private static IScheduler _scheduler;

        public IncluirFreteMedioMIS()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();
            _scheduler.Start();
            StartJob();                        
        }

        public static void StartJob()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
            _scheduler.Start();

            IJobDetail job = JobBuilder.Create<IncluirFreteMedioMISJob>().Build();
                        
            var trigger = TriggerBuilder.Create()
                                        .ForJob(job)
                                        .WithIdentity("trigger")
                                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(ConfigurationServiceUtil.HoraInicioExecucaoServico, ConfigurationServiceUtil.MinutoInicioExecucaoServico))
                                        .Build();

            _scheduler.ScheduleJob(job, trigger);
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("IncluirFreteMedioMIS", "STOP DA EXECUÇÃO - parcelamentoService.ExportarParcelamento();", EventLogEntryType.Information);
        }

        public override void Execute()
        {
            EventLog.WriteEntry("IncluirFreteMedioMIS", "INICIO DA EXECUÇÃO - parcelamentoService.ExportarParcelamento();", EventLogEntryType.Information);
            Thread.Sleep(System.TimeSpan.FromMinutes(5));
            EventLog.WriteEntry("IncluirFreteMedioMIS", "FIM DA EXECUÇÃO - parcelamentoService.ExportarParcelamento();", EventLogEntryType.Information);
        }
    }
}
