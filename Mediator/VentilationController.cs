/****************/
// 202418944
// Bùi Nhật Minh
/****************/
namespace CampusSafetyHub.Mediator;

public sealed class VentilationController
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator) => this.mediator = mediator;

    public void Shutdown()
    {
        Console.WriteLine("[VENTILATION] Da tat he thong thong gio de khoi khong lan rong");
        mediator?.Notify(this, "VENTILATION_OFF");
    }

    public void Start()
    {
        Console.WriteLine("[VENTILATION] He thong dang chay");
        mediator?.Notify(this, "VENTILATION_ON");
    }
}
