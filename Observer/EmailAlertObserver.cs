namespace CampusSafetyHub.Observer;

public sealed class EmailAlertObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[EMAIL] To: admin@campus.edu | " +
            $"Subject: {alertEvent.Severity} at {alertEvent.SensorName} | " +
            $"Value: {alertEvent.Value:F1}{alertEvent.Unit}");
    }
}
