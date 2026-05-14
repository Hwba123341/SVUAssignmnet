# VehicleRentalSystem

Console application (.NET **8.0**, nullable reference types enabled) demonstrating core **Object-Oriented Programming** concepts for coursework (Syrian Virtual University style specifications).

Open `VehicleRentalSystem.sln` in **Visual Studio 2022** or run:

```powershell
dotnet run --project VehicleRentalSystem\VehicleRentalSystem.csproj
```

## Folder layout

```
VehicleRentalSystem/
├── Abstracts/Vehicle.cs
├── Delegates/RentalDelegates.cs
├── Interfaces/IVehicle.cs
├── Models/Car.cs, Truck.cs, Motorcycle.cs
├── Services/RentalAgency.cs, Validator.cs
├── Program.cs
└── README.md
```

## OOP principles mapped to source

| Principle | Where it appears |
|-----------|------------------|
| **Abstraction** | `Interfaces/IVehicle.cs` hides concrete types behind a behavioral contract; `Abstracts/Vehicle.cs` fixes shared state and `DisplayDetails` while leaving `CalculateRentalCost` abstract. |
| **Inheritance** | `Car`, `Truck`, and `Motorcycle` derive from `Vehicle` and specialize fields and overridden methods in `Models/`. |
| **Polymorphism** | `Services/RentalAgency.ShowFleet()` calls `Vehicle.DisplayDetails()` on heterogeneous instances (runtime resolves to derived overrides). `CalculateRentalCost` overrides supply subtype-specific tariffs. |
| **Encapsulation** | Private backing fields (`_model`, `_licensePlate`, `_year`, `_isRented`, etc.). `LicensePlate` is getter-only externally. `IsRented` uses an `internal` setter so trusted code in this assembly transitions rental state. |
| **Delegates & events** | `Delegates/RentalDelegates.cs` defines `RentalTransactionHandler`; `RentalAgency` exposes `OnVehicleRented` and `OnVehicleReturned`, raised after operations with messages including plates and totals. |
| **Static utilities & counters** | `Services/Validator.cs` validates construction invariants (`ArgumentException` on failure). `Vehicle.TotalVehiclesCreated` increments in the base constructor once validation succeeds. |

## Rental pricing rules (implemented)

- **Car:** USD **50.00** per calendar day
- **Truck:** USD **120.00** per day
- **Motorcycle:** USD **30.00**/day for the first **three** days, then **20.00**/day afterward

Prices are illustrative academic constants—not production billing.
