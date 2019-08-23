namespace DrivelessCar.Interfaces
{
    public interface ICar
    {
        void move(string command);
        int getPositionX();
        int getPositionY();
        string getOrientation();
    }
}
