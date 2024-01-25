using System;
using System.Timers;

namespace SystemOfDoor
{
    public class DoorTimer : ITimer
    {
        private Timer timer;

        public event ElapsedEventHandler Elapsed;

        public void StartTimer(int interval)
        {
            timer = new Timer(interval);
            timer.Elapsed += OnElapsed;
            timer.AutoReset = false;
            timer.Start();
        }

        public void StopTimer()
        {
            timer?.Stop();
        }

        public void OnElapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed?.Invoke(sender, e);
        }
    }
}
