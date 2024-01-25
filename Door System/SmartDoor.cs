using System;

namespace SystemOfDoor
{
    public class SmartDoor : SimpleDoor
    {
        private readonly ITimer doorTimer;
        private int timerInterval;

        public event Action Alert;

        public SmartDoor(ITimer doorTimer)
        {
            this.doorTimer = doorTimer;
        }

        public void SetTimeInterval(int timeInterval)
        {
            timerInterval = timeInterval;
        }

        public override void OpenDoor()
        {
            base.OpenDoor();
            doorTimer.Elapsed += TimerElapsed;
            doorTimer.StartTimer(timerInterval);
        }

        public override void CloseDoor()
        {
            doorTimer.StopTimer();
            doorTimer.Elapsed -= TimerElapsed;

            base.CloseDoor();
        }

        public void TimerElapsed(object sender, EventArgs e)
        {
            Alert?.Invoke();
        }
    }
}
