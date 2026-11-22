namespace CampusSafetyHub.Mediator;

public sealed class DoorController
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator) => this.mediator = mediator;

    public void UnlockAll()
    {
        Console.WriteLine("[DOOR] Da mo khoa cac loi thoat hiem");
        mediator?.Notify(this, "DOORS_UNLOCKED");
    }

    public void LockAll()
    {
        Console.WriteLine("[DOOR] Da khoa cua");
        mediator?.Notify(this, "DOORS_LOCKED");
    }
}
