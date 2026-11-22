namespace CampusSafetyHub.Observer;

public interface IAlertObserver
{
    void Update(AlertEvent alertEvent);
}
