using System;
using DrivelessCar.Interfaces;
using DrivelessCar.Common;
using DrivelessCar.Exceptions;
using DrivelessCar.Components;

namespace DrivelessCar.Commands
{
    public class CommandGenerator : ICommandGenerator
    {
        private ICommand _command;
        private IPrinter _printer;
        private ICar _car;

        public CommandGenerator(int width, int height)
        {
            _car = new CarModule.Car(width, height);
            _command = new MoveCommand(_car);
            _printer = new Printer();
        }

        public void GenerateCommand()
        {
            _printer.Print("The Car's start position is the top left corner!");
            _printer.ChangeLine();
            _printer.Print($"The Car is in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}");
            _printer.ChangeLine();
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

                    var msg = $"The Car is in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}";
                    _printer.Print(msg);
                    _printer.ChangeLine();
                }
                catch (OutOfBoardException)
                {
                    _printer.Print("Car run out of boundary! Rest car position!");
                    _printer.ChangeLine();
                }
            }
        }
    }
}
