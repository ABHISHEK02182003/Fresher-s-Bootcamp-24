using System;

namespace SystemOfDoor
{
    public class SimpleDoor
    {
        private DoorState state;

        public DoorState State
        {
            get { return state; }
        }


        public SimpleDoor()
        {
            state = DoorState.Closed;
        }

        public virtual void OpenDoor()
        {
            state = DoorState.Opened;
            Console.WriteLine("Door is now open.");
        }

        public virtual void CloseDoor()
        {
            state = DoorState.Closed;
            Console.WriteLine("Door is now closed.");
        }
    }
}

