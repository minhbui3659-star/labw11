/****************/
// 202418944
// Bùi Nhật Minh
/****************/
using CampusSafetyHub.Adapter;
using CampusSafetyHub.Mediator;
using CampusSafetyHub.Observer;

namespace CampusSafetyHub;

class Program
{
    static void Main()
    {
        Run("T1: Adapter", () =>
        {
            var legacy = new LegacySmokeDetector(735);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            Console.WriteLine(sensor.ReadValue()); // 73.5
            Console.WriteLine(sensor.GetUnit());   // % smoke
        });

        Run("T2: Duoi 50% khong canh bao", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            AttachBasic(monitor);
            foreach (int level in new[] { 300, 499 })
            {
                legacy.SetSmokeLevel(level);
                monitor.CheckSensor("D3-102", sensor);
                Console.WriteLine($"Da kiem tra {sensor.ReadValue()}{sensor.GetUnit()}");
            }
        });

        Run("T3: WARNING, mediator khong chay", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            AttachBasic(monitor);
            monitor.Attach(new EmergencyBridgeObserver(NewMediator()));
            foreach (int level in new[] { 500, 699 })
            {
                legacy.SetSmokeLevel(level);
                monitor.CheckSensor("D3-102", sensor);
            }
        });

        Run("T4: CRITICAL, mediator chay", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            AttachBasic(monitor);
            monitor.Attach(new EmergencyBridgeObserver(NewMediator()));
            legacy.SetSmokeLevel(700);
            monitor.CheckSensor("D3-102", sensor);
        });

        Run("T5: Attach 2 lan chi nhan 1 lan", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            var dashboard = new DashboardObserver();
            monitor.Attach(dashboard);
            monitor.Attach(dashboard);
            legacy.SetSmokeLevel(600);
            monitor.CheckSensor("D3-102", sensor);
        });

        Run("T6: Detach", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            var dashboard = new DashboardObserver();
            monitor.Attach(dashboard);
            monitor.Attach(new AuditLogObserver());
            legacy.SetSmokeLevel(600);
            Console.WriteLine("-- truoc detach");
            monitor.CheckSensor("D3-102", sensor);
            monitor.Detach(dashboard);
            Console.WriteLine("-- sau detach");
            monitor.CheckSensor("D3-102", sensor);
        });

        Run("T7: Observer tu go minh khi dang duoc thong bao", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            IAlertObserver? self = null;
            self = new ActionObserver(e =>
            {
                Console.WriteLine("[SELF-DETACH] Nhan canh bao, tu go khoi monitor");
                monitor.Detach(self!);
            });
            monitor.Attach(self);
            monitor.Attach(new DashboardObserver());
            legacy.SetSmokeLevel(600);
            Console.WriteLine("-- lan 1");
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine("-- lan 2");
            monitor.CheckSensor("D3-102", sensor);
        });

        Run("T8: Observer nem ngoai le", () =>
        {
            var (legacy, sensor, monitor) = Setup();
            monitor.Attach(new ActionObserver(e => throw new InvalidOperationException("Observer gia lap loi")));
            monitor.Attach(new DashboardObserver());
            legacy.SetSmokeLevel(600);
            monitor.CheckSensor("D3-102", sensor);
        });
    }

    static (LegacySmokeDetector, ISensor, SensorMonitor) Setup()
    {
        var legacy = new LegacySmokeDetector(0);
        return (legacy, new SmokeSensorAdapter(legacy), new SensorMonitor());
    }

    static void AttachBasic(SensorMonitor monitor)
    {
        monitor.Attach(new DashboardObserver());
        monitor.Attach(new EmailAlertObserver());
        monitor.Attach(new AuditLogObserver());
    }

    static EmergencyMediator NewMediator() =>
        new(new Alarm(), new DoorController(), new VentilationController());

    static void Run(string name, Action test)
    {
        Console.WriteLine($"=== {name} ===");
        try
        {
            test();
            Console.WriteLine("=> Xong");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"=> LOI: {ex.Message}");
        }
        Console.WriteLine();
    }
}
