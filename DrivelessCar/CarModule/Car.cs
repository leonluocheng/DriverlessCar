using System;
using DrivelessCar.Interfaces;
using DrivelessCar.Common;
using DrivelessCar.Exceptions;

namespace DrivelessCar.CarModule
{
    public class Car : ICar
    {
        public int positionX;
        public int positionY;
        public Orientation orientation;
        private int[,] _board;

        public Car(int width, int height)
        {
            _board = new int[width, height];
            resetCarPosition();
        }

        public string getOrientation()
        {
            return orientation.ToString();
        }

        public int getPositionX()
        {
            return positionX;
        }

        public int getPositionY()
        {
            return positionY;
        }

        public void move(string command)
        {
            if(command == Command.forward.ToString())
            {
                forward();
            }

            if(command == Command.turn.ToString())
            {
                turn();
            }
        }

        private void forward()
        {
            try
            {
                //Y -1
                if (orientation == Orientation.North)
                {
                    _board[positionX, positionY] = 0;
                    _board[positionX, --positionY] = 1;
                }

                //Y + 1
                if (orientation == Orientation.South)
                {
                    _board[positionX, positionY] = 0;
                    _board[positionX, ++positionY] = 1;
                }

                //X -1
                if (orientation == Orientation.West)
                {
                    _board[positionX, positionY] = 0;
                    _board[--positionX, positionY] = 0;
                }

                //X +1
                if (orientation == Orientation.East)
                {
                    _board[positionX, positionY] = 0;
                    _board[++positionX, positionY] = 0;
                }
            }
            catch (IndexOutOfRangeException)
            {
                resetCarPosition();
                throw new OutOfBoardException("Car is run out of boundary! Rest");
            }

        }

        private void turn()
        {
            if(orientation == Orientation.North)
            {
                orientation = Orientation.East;
                return;
            }

            if(orientation == Orientation.East)
            {
                orientation = Orientation.South;
                return;
            }

            if(orientation == Orientation.South)
            {
                orientation = Orientation.West;
                return;
            }

            if(orientation == Orientation.West)
            {
                orientation = Orientation.North;
                return;
            }
        }

        private void resetCarPosition()
        {
            InitilizeBoard();
            _board[0, 0] = 1;
            positionX = 0;
            positionY = 0;
            orientation = Orientation.North;
        }

        private void InitilizeBoard()
        {
            for (var i = 0; i < getWidth(); i++)
            {
                for (var j = 0; j < getHeight(); j++)
                {
                    _board[i, j] = 0;
                }
            }
        }

        private int getWidth()
        {
            return _board.GetLength(0);
        }

        private int getHeight()
        {
            return _board.GetLength(1);
        }
    }
}
