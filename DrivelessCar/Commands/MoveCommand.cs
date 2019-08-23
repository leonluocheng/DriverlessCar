using DrivelessCar.Interfaces;

namespace DrivelessCar.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly ICar _car;

        public MoveCommand(ICar car)
        {
            _car = car;
        }

        public void Execute(string command)
        {
            _car.move(command);
        }
    }
}
