using System;
using DrivelessCar.Interfaces;

namespace DrivelessCar.Components
{
    public class Printer : IPrinter
    {
        public void ChangeLine()
        {
            Console.WriteLine();
        }

        public void Print(string msg)
        {
            Console.Write(msg);
        }
    }
}
