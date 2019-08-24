using DrivelessCar.Common;
namespace DrivelessCar.Interfaces
{
    public interface ICar
    {
        void move(string command);
        int getPositionX();
        int getPositionY();
        string getOrientation();
        void Create(int width, int height, Orientation orientation);
    }
}
