namespace CampusSafetyHub.Mediator;

public interface IEmergencyMediator
{
    void Notify(object sender, string eventCode);
}
