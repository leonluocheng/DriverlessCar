using Xunit;
using DrivelessCar.Interfaces;
using DrivelessCar.CarModule;
using DrivelessCar.Common;
using DrivelessCar.Commands;
using FluentAssertions;
using System;
using DrivelessCar.Exceptions;

namespace DrivelessCarTest
{
    public class CarMovementTests
    {
        private ICar _car;
        private int width = 5;
        private int height = 5;
        private ICommand _command;

        [Fact]
        public void ShouldThrowExceptionAndRestToPreviousPositionIfCarRunOutOfBoundary()
        {
            _car = new Car();
            _command = new MoveCommand(_car);
            _car.Create(width, height, Orientation.East);

            Action act = () =>
            {
                for (var i = 0; i < 5; i++)
                {
                    _command.Execute(Command.forward.ToString());
                }
            };

            act.Should().Throw<OutOfBoardException>();
            _car.getPositionX().Should().Be(4);
            _car.getPositionY().Should().Be(0);
            _car.getOrientation().Should().Be(Orientation.East.ToString());
        }

        [Fact]
        public void CarShouldMoveToTheCorrectPosition()
        {
            _car = new Car();
            _command = new MoveCommand(_car);
            _car.Create(width, height, Orientation.East);

            _command.Execute(Command.forward.ToString());
            _command.Execute(Command.turn.ToString());
            _command.Execute(Command.forward.ToString());
            _command.Execute(Command.forward.ToString());
            _command.Execute(Command.forward.ToString());
            _command.Execute(Command.turn.ToString());
            _command.Execute(Command.turn.ToString());

            _car.getPositionX().Should().Be(1);
            _car.getPositionY().Should().Be(3);
            _car.getOrientation().Should().Be(Orientation.North.ToString());
        }
    }
}
