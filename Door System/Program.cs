using System;
using SystemOfDoor;

namespace DoorsSystem
{
    class Program
    {
        static void Main()
        {
            ITimer doorTimer = new DoorTimer();
            SmartDoor smartDoor = new SmartDoor(doorTimer);

            AdditionalFeatures buzzor = new Buzzor();
            AdditionalFeatures pager = new Pager();
            AdditionalFeatures autoCloseFunction = new AutoClose();

            smartDoor.Alert += () =>
            {
                buzzor.Activate(smartDoor);
                pager.Activate(smartDoor);
                autoCloseFunction.Activate(smartDoor);
            };
            
            smartDoor.SetTimeInterval(2);
            smartDoor.OpenDoor();

            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}
