/****************/
// 202418944
// Bùi Nhật Minh
/****************/
namespace CampusSafetyHub.Observer;

public sealed class DashboardObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[DASHBOARD] {alertEvent.SensorName}: " +
            $"{alertEvent.Value:F1}{alertEvent.Unit} " +
            $"[{alertEvent.Severity}]");
    }
}
