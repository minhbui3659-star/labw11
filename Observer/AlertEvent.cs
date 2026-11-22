/****************/
// 202418944
// Bùi Nhật Minh
/****************/
namespace CampusSafetyHub.Observer;

public sealed record AlertEvent(
    string SensorName,
    double Value,
    string Unit,
    string Severity,
    DateTime OccurredAt);
