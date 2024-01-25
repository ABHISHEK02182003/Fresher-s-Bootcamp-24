using System;

namespace DoorsSystem
{
    public class DoorController
    {
        public void SubscribeToDoorEvents(SimpleDoor door)
        {
            door.DoorStateChanged += HandleDoorStateChanged;
        }

        private void HandleDoorStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Door state changed!");
        }

        public void SubscribeToSmartDoorEvents(SmartDoor smartDoor)
        {
            SubscribeToDoorEvents(smartDoor);

            smartDoor.AutoClose += HandleAutoClose;
            smartDoor.BuzzorAlert += HandleBuzzorAlert;
            smartDoor.PagerNotification += HandlePagerNotification;
        }

        private void HandleAutoClose(object sender, EventArgs e)
        {
            Console.WriteLine("Smart Door Auto Closed!");
        }

        private void HandleBuzzorAlert(object sender, EventArgs e)
        {
            Console.WriteLine("Buzzor Alert Activated!");
        }

        private void HandlePagerNotification(object sender, EventArgs e)
        {
            Console.WriteLine("Pager Notification Sent!");
        }
    }
}
