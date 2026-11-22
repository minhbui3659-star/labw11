namespace CampusSafetyHub.Adapter;

public interface ISensor
{
    double ReadValue();
    string GetUnit();
}
