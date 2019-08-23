using System;
using DrivelessCar.Commands;
using DrivelessCar.Common;

namespace DrivelessCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input board width: ");
            var width = Console.ReadLine();
            Console.Write("Please input board height: ");
            var height = Console.ReadLine();
            var generator = new CommandGenerator(width.StringToInt(), height.StringToInt());

            generator.GenerateCommand();
        }
    }
}
