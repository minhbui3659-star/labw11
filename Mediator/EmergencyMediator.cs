namespace CampusSafetyHub.Mediator;

public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController door;
    private readonly VentilationController ventilation;

    public EmergencyMediator(Alarm alarm, DoorController door, VentilationController ventilation)
    {
        this.alarm = alarm ?? throw new ArgumentNullException(nameof(alarm));
        this.door = door ?? throw new ArgumentNullException(nameof(door));
        this.ventilation = ventilation ?? throw new ArgumentNullException(nameof(ventilation));

        alarm.SetMediator(this);
        door.SetMediator(this);
        ventilation.SetMediator(this);
    }

    public void Notify(object sender, string eventCode)
    {
        if (eventCode == "FIRE_DETECTED")
        {
            Console.WriteLine("[MEDIATOR] FIRE_DETECTED -> kich hoat quy trinh khan cap");
            alarm.Trigger();
            door.UnlockAll();
            ventilation.Shutdown();
        }
    }
}
