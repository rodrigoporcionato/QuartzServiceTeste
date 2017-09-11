using System.ServiceProcess;
using System.Timers;

namespace QuartzServiceTeste
{
    public class CustomService : ServiceBase
    {
        #region Properties

        private Timer _timer = null;

        protected Timer TimerService
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new Timer();
                    _timer.Interval = ConfigurationServiceUtil.Interval;
                    _timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                }

                return _timer;
            }
            set { }
        }

        #endregion

        #region Constructor

        public CustomService()
        {
        }

        public CustomService(bool canPauseAndContinue)
        {
            this.CanPauseAndContinue = canPauseAndContinue;
        }

        #endregion

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            _timer.Stop();
            Execute();
            _timer.Start();
        }

        public virtual void Execute() { }

    }
}
