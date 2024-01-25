using System;

namespace SystemOfDoor
{
    public class AutoClose : AdditionalFeatures
    {
        public void Activate(SmartDoor smartDoor)
        {
            if (smartDoor.State == DoorState.Opened)
            {
                //Console.WriteLine("Auto closing the door...");
                smartDoor.CloseDoor();
            }
        }
    }
}
