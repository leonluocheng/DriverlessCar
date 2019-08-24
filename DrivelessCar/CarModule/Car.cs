using System;
using DrivelessCar.Interfaces;
using DrivelessCar.Common;
using DrivelessCar.Exceptions;

namespace DrivelessCar.CarModule
{
    public class Car : ICar
    {
        private int positionX;
        private int positionY;
        private Orientation orientation;

        private int previousPositionX;
        private int previousPositionY;
        private Orientation previousOrientation;

        private Orientation defaultOrientation;
        private int[,] _board;

        public void Create(int width, int height, Orientation orientation)
        {
            _board = new int[width, height];
            defaultOrientation = orientation;
            InitilizePosition();
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
                previousPositionX = positionX;
                previousPositionY = positionY;
                previousOrientation = orientation;

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
                    _board[--positionX, positionY] = 1;
                }

                //X +1
                if (orientation == Orientation.East)
                {
                    _board[positionX, positionY] = 0;
                    _board[++positionX, positionY] = 1;
                }
            }
            catch (IndexOutOfRangeException)
            {
                resetCarPosition();
                throw new OutOfBoardException("Car is run out of boundary! Rest!");
            }

        }

        private void turn()
        {
            previousOrientation = orientation;
            if (orientation == Orientation.North)
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
            _board[previousPositionX, previousPositionY] = 1;
            positionX = previousPositionX;
            positionY = previousPositionY;
            orientation = previousOrientation;
        }

        private void InitilizePosition()
        {
            InitilizeBoard();
            _board[0, 0] = 1;
            positionX = 0;
            positionY = 0;
            orientation = defaultOrientation;
            previousOrientation = defaultOrientation;
            previousPositionX = 0;
            previousPositionY = 0;
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
