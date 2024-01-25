using System;

namespace DoorsSystem
{
    class Program
    {
        static void Main()
        {
            Buzzor buzzor = new Buzzor();
            Pager pager = new Pager();
            AutoCloseFunction autoCloseFunction = new AutoCloseFunction();

            SimpleDoor simpleDoor = new SimpleDoor();
            SmartDoor smartDoor = new SmartDoor(buzzor, pager, autoCloseFunction);

            DoorController doorController = new DoorController();

            doorController.SubscribeToDoorEvents(simpleDoor);

            doorController.SubscribeToSmartDoorEvents(smartDoor);

            Console.WriteLine("Opening Simple Door");
            simpleDoor.Open();
            Console.WriteLine();

            Console.WriteLine("Opening Smart Door");
            smartDoor.Open();
            smartDoor.AutoCloseTime = 5;
            smartDoor.SetTimer(); 
            Console.WriteLine();

            Console.WriteLine("Waiting for events (press Enter to exit)...");
            Console.ReadLine();
        }
    }
}
