using System;
using DrivelessCar.Interfaces;
using DrivelessCar.Common;
using DrivelessCar.Exceptions;

namespace DrivelessCar.Commands
{
    public class CommandGenerator : ICommandGenerator
    {
        private readonly ICommand _command;
        private readonly IPrinter _printer;
        private readonly ICar _car;

        public CommandGenerator(ICar car, ICommand command, IPrinter printer)
        {
            _car = car;
            _command = command;
            _printer = printer;
        }

        public void GenerateCommand()
        {
            CreateCarModel();
            while (true)
            {
                try
                {
                    Random random = new Random();
                    var commandmsg = ((Command)random.Next(0, 2)).ToString();
                    System.Threading.Thread.Sleep(5000);
                    _printer.Print($"Command: {commandmsg}");
                    _printer.ChangeLine();

                    _command.Execute(commandmsg);

                    var msg = $"The Car is now in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}";
                    _printer.Print(msg);
                    _printer.ChangeLine();
                }
                catch (OutOfBoardException)
                {
                    _printer.Print("Car run out of boundary! Rest car to perivous position!");
                    _printer.ChangeLine();
                    var msg = $"The Car is now in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}";
                    _printer.Print(msg);
                    _printer.ChangeLine();
                }
            }
        }

        private void CreateCarModel()
        {
            _printer.Print("Please input board width: ");
            var width = Console.ReadLine();
            _printer.Print("Please input board height: ");
            var height = Console.ReadLine();

            //Assume default orientation is north;
            _car.Create(width.StringToInt(), height.StringToInt(), Orientation.East);

            _printer.Print("The Car's start position is the top left corner!");
            _printer.ChangeLine();
            _printer.Print($"The Car is in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}");
            _printer.ChangeLine();
        }
    }
}
