using System;
using System.Threading;
// Encapsulated family of Algorithms
// Interface and its implementations
public interface IBrakeBehavior
{
    void Brake();
}

public class BrakeWithABS : IBrakeBehavior
{
    public void Brake()
    {
        Console.WriteLine("Brake with ABS applied");
    }
}

public class SimpleBrake : IBrakeBehavior // Renamed from Brake
{
    public void Brake()
    {
        Console.WriteLine("Simple Brake applied");
    }
}

// Abstract Template Class (Template Method Pattern)
public abstract class Car
{
    private IBrakeBehavior brakeBehavior;

    public Car(IBrakeBehavior brakeBehavior)
    {
        this.brakeBehavior = brakeBehavior;
    }
    public void ApplyBrake() // this is the strategy method
    {
        brakeBehavior.Brake();
    }

    public abstract void Drive();  // Template method

    public void Start()
    {
        Console.WriteLine("Starting the car engine.");
        Drive();
        Console.WriteLine("Car stopped.");
    }

    public void SetBrakeBehavior(IBrakeBehavior brakeType)
    {
        this.brakeBehavior = brakeType;
    }
}

// Concrete subclasses
public class Sedan : Car
{
    public Sedan() : base(new SimpleBrake()) // Use SimpleBrake here
    {
    }

    public override void Drive()
    {
        Console.WriteLine("Sedan is driving.");
        ApplyBrake();
        
    }
}

public class SUV : Car
{
    public SUV() : base(new BrakeWithABS())
    {
    }

    public override void Drive()
    {
        Console.WriteLine("SUV is driving.");
        ApplyBrake();
    }
}

// Using the Car example
class CarExample
{
    static void Main(string[] args)
    {
        Car sedanCar = new Sedan();
        sedanCar.Start();  // This will invoke "SimpleBrake" for braking and "Sedan is driving." for driving
        
        Thread.Sleep(500);
        Console.WriteLine();
        
        Car suvCar = new SUV();
        suvCar.Start();    // This will invoke "BrakeWithABS" for braking and "SUV is driving." for driving
    }
}
