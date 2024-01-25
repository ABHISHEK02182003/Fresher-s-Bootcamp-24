using System;
using System.Runtime.Remoting;

namespace SystemOfDoor
{
    public interface AdditionalFeatures
    {
        void Activate(SmartDoor smartDoor);
    }
}