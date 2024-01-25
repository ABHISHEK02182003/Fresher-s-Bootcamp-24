using System;

namespace DoorsSystem
{
    public class SimpleDoor
    {
        private DoorState state;

        public DoorState State
        {
            get { return state; }
            private set
            {
                state = value;
                OnDoorStateChanged();
            }
        }

        public event EventHandler DoorStateChanged;

        public void Open()
        {
            State = DoorState.Opened;
        }

        public void Close()
        {
            State = DoorState.Closed;
        }

        protected virtual void OnDoorStateChanged()
        {
            DoorStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
