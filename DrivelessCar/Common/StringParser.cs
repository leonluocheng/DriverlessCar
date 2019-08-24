using System;
namespace DrivelessCar.Common
{
    public static class StringParser
    {
        public static int StringToInt(this string arg)
        {
            if (!int.TryParse(arg, out int result) || result < 1)
                throw new ArgumentException();

            return result;
        }
    }
}
