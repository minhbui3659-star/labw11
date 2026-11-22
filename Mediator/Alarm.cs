/****************/
// 202418944
// Bùi Nhật Minh
/****************/
namespace CampusSafetyHub.Mediator;

public sealed class Alarm
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator) => this.mediator = mediator;

    public void Trigger()
    {
        Console.WriteLine("[ALARM] Con hu dang keu!");
        mediator?.Notify(this, "ALARM_ON");
    }

    public void Reset()
    {
        Console.WriteLine("[ALARM] Da tat con hu.");
        mediator?.Notify(this, "ALARM_OFF");
    }
}
