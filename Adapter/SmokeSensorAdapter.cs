namespace CampusSafetyHub.Adapter;

public sealed class SmokeSensorAdapter : ISensor
{
    private readonly LegacySmokeDetector legacy;

    public SmokeSensorAdapter(LegacySmokeDetector legacy)
    {
        this.legacy = legacy ??
            throw new ArgumentNullException(nameof(legacy));
    }

    // doi 0..1000 thanh 0..100 (%)
    public double ReadValue()
    {
        return legacy.GetSmokeLevel() / 10.0;
    }

    public string GetUnit() => "% smoke";
}
