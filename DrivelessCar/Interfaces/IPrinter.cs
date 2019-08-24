using System;
namespace DrivelessCar.Interfaces
{
    public interface IPrinter
    {
        void Print(string msg);
        void ChangeLine();
    }
}
