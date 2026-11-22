/****************/
// 202418944
// Bùi Nhật Minh
/****************/
namespace CampusSafetyHub.Observer;

// observer dung de test: chay mot hanh dong tuy y khi nhan canh bao
public sealed class ActionObserver : IAlertObserver
{
    private readonly Action<AlertEvent> action;

    public ActionObserver(Action<AlertEvent> action)
    {
        this.action = action;
    }

    public void Update(AlertEvent alertEvent) => action(alertEvent);
}
