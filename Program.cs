using VehicleRentalSystem.Abstracts;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.Services;

namespace VehicleRentalSystem;

/// <summary>Console entry point demonstrating OOP requirements for IPG assignment.</summary>
internal static class Program
{
    private static void Main()
    {
        var agency = new RentalAgency();

        agency.OnVehicleRented += (sender, msg) =>
            Console.WriteLine($"[Event] {(sender?.GetType().Name ?? "?")}: {msg}");
        agency.OnVehicleReturned += (sender, msg) =>
            Console.WriteLine($"[Event] {(sender?.GetType().Name ?? "?")}: {msg}");

        agency.AddVehicle(new Car("Toyota Corolla", "ABC123", 2022, 5, "Gasoline"));
        agency.AddVehicle(new Car("Honda Civic", "XYZ789", 2021, 5, "Hybrid"));
        agency.AddVehicle(new Truck("Volvo FH16", "TRK4421", 2019, 25.5m, 3));
        agency.AddVehicle(new Motorcycle("Harley Davidson", "MOTO99", 2020, 1200, false));

        agency.ShowFleet();

        agency.ProcessRental("ABC123");   // car
        agency.ProcessRental("MOTO99");  // motorcycle

        agency.ProcessReturn("ABC123", 5);  // Car: $50/day * 5 = $250
        agency.ProcessReturn("MOTO99", 5);  // Motorcycle: 3*$30 + 2*$20 = $130

        Console.WriteLine();
        Console.WriteLine("--- Invalid construction (expected exception) ---");
        try
        {
#pragma warning disable CS0168
            Vehicle bad = new Car("Ford", "BAD01", 1850, 4, "Diesel"); // Validator throws invalid year before ctor completes
#pragma warning restore CS0168
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught ArgumentException: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine($"Total vehicles successfully constructed so far: {Vehicle.TotalVehiclesCreated}");

        // vehicle.LicensePlate = "NEW"; // Compile Error (Encapsulation).
        Console.WriteLine();
        Console.WriteLine("Demo complete.");
    }
}
