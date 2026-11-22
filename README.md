# Lab 11 – Câu hỏi thiết kế

1. **Adapter nên kế thừa hay chứa `LegacySmokeDetector`?** Nên chứa. Lớp cũ là `sealed`, và Adapter đọc trực tiếp giá trị hiện tại từ lớp đó.
2. **`SensorMonitor` có nên biết `EmailAlertObserver` cụ thể không?** Không. Monitor chỉ cần biết `IAlertObserver` để có thể thêm hoặc gỡ bất kỳ bên nhận nào.
3. **`Alarm` có cần tham chiếu đến `DoorController` không?** Không. Mediator điều phối các thiết bị. Khi đổi quy trình, chỉ cần sửa mediator và vẫn dùng lại được các thiết bị.
4. **Ai quyết định giá trị nào vượt ngưỡng?** `SensorMonitor`: từ 50% là `WARNING`, từ 70% là `CRITICAL`.

## Sơ đồ lớp UML

[Mã nguồn PlantUML](uml_a11.puml)
