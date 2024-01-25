using System;
using System.Threading;

namespace DoorsSystem
{
    public class SmartDoor : SimpleDoor
    {
        private int autoCloseTime;
        private Timer timer;

        private Buzzor buzzor;
        private Pager pager;
        private AutoCloseFunction autoCloseFunction;

        public SmartDoor(Buzzor buzzor, Pager pager, AutoCloseFunction autoCloseFunction)
        {
            this.buzzor = buzzor;
            this.pager = pager;
            this.autoCloseFunction = autoCloseFunction;
        }

        public int AutoCloseTime
        {
            get { return autoCloseTime; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Auto close time should be greater than 0");
                }

                autoCloseTime = value;
            }
        }

        public void SetTimer()
        {
            timer = new Timer(CheckAutoClose, null, autoCloseTime * 1000, Timeout.Infinite);
        }

        private void CheckAutoClose(object state)
        {
            Console.WriteLine("Door opened for too long! Making noise...");
            OnAutoClose();
            OnBuzzorAlert();
            OnPagerNotification();
        }

        protected virtual void OnAutoClose()
        {
            AutoClose?.Invoke(this, EventArgs.Empty);

            // Use AutoCloseFunction
            autoCloseFunction.CloseDoor();
        }

        protected virtual void OnBuzzorAlert()
        {
            BuzzorAlert?.Invoke(this, EventArgs.Empty);

            buzzor.Activate();
        }

        protected virtual void OnPagerNotification()
        {
            PagerNotification?.Invoke(this, EventArgs.Empty);

            pager.SendNotification();
        }

        public event EventHandler AutoClose;
        public event EventHandler BuzzorAlert;
        public event EventHandler PagerNotification;
    }
}
