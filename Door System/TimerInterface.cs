using System.Timers;

namespace SystemOfDoor
{
    public interface ITimer
    {
        event ElapsedEventHandler Elapsed;

        void StartTimer(int interval);
        void StopTimer();
    }
}