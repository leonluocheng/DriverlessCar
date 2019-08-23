using System;
namespace DrivelessCar.Exceptions
{
    public class OutOfBoardException : Exception
    {
        public OutOfBoardException(string msg):base(msg)
        {
        }
    }
}
