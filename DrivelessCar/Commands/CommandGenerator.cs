using System;
using DrivelessCar.Interfaces;
using DrivelessCar.Common;
using DrivelessCar.Exceptions;
using DrivelessCar.Components;

namespace DrivelessCar.Commands
{
    public class CommandGenerator : ICommandGenerator
    {
        private Random random = new Random();
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
            _printer.Print($"The Car is in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}");
            while (true)
            {
                try
                {
                    var commandmsg = ((Command)random.Next(0, 1)).ToString();
                    _printer.Print($"Command: {commandmsg}");
                    System.Threading.Thread.Sleep(5000);
                    _command.Execute(commandmsg);

                    var msg = $"The Car is in position X = {_car.getPositionX()} and Y = {_car.getPositionY()} and facing {_car.getOrientation()}";
                    _printer.Print(msg);
                }
                catch (OutOfBoardException)
                {
                    _printer.Print("Car run out of boundary! Rest car position!");
                }
            }
        }
    }
}
