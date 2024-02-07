// // Empty vocabulary of actual object
# region factory method pattern
// using System;

// public interface IPerson
// {
//     string GetName();
// }

// public class Villager : IPerson
// {
//     public string GetName()
//     {
//         return "Village Person";
//     }
// }

// public class CityPerson : IPerson
// {
//     public string GetName()
//     {
//         return "City Person";
//     }
// }

// public enum PersonType
// {
//     Rural,
//     Urban
// }

// /// <summary>
// /// Implementation of Factory - Used to create objects.
// /// </summary>
// public class PersonFactory
// {
//     public IPerson GetPerson(PersonType type)
//     {
//         switch (type)
//         {
//             case PersonType.Rural:
//                 return new Villager();
//             case PersonType.Urban:
//                 return new CityPerson();
//             default:
//                 throw new NotSupportedException();
//         }
//     }
// }


// public class Program
// {
//     static void Main(string[] args)
//     {
//         PersonFactory factory = new PersonFactory();

//         IPerson ruralPerson = factory.GetPerson(PersonType.Rural);
//         IPerson urbanPerson = factory.GetPerson(PersonType.Urban);

//         Console.WriteLine("Rural person: " + ruralPerson.GetName());
//         Console.WriteLine("Urban person: " + urbanPerson.GetName());
//     }
// }

#endregion

#region ABstract Factory Pattern
using System;

// Abstract Product A
public interface ICar
{
    void Drive();
}

// Concrete Product A1
public class Sedan : ICar
{
    public void Drive()
    {
        Console.WriteLine("Driving a Sedan");
    }
}

// Concrete Product A2
public class SUV : ICar
{
    public void Drive()
    {
        Console.WriteLine("Driving an SUV");
    }
}

// Abstract Product B
public interface IEngine
{
    void Start();
}

// Concrete Product B1
public class GasolineEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Gasoline Engine started");
    }
}

// Concrete Product B2
public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric Engine started");
    }
}

// Abstract Factory
public interface IVehicleFactory
{
    ICar CreateCar();
    IEngine CreateEngine();
}

// Concrete Factory 1
public class EconomyCarFactory : IVehicleFactory
{
    public ICar CreateCar()
    {
        return new Sedan();
    }

    public IEngine CreateEngine()
    {
        return new GasolineEngine();
    }
}

// Concrete Factory 2
public class LuxuryCarFactory : IVehicleFactory
{
    public ICar CreateCar()
    {
        return new SUV();
    }

    public IEngine CreateEngine()
    {
        return new ElectricEngine();
    }
}
#endregion

// Client
class Program
{
    static void Main(string[] args)
    {
        IVehicleFactory economyFactory = new EconomyCarFactory();
        ICar economyCar = economyFactory.CreateCar();
        IEngine economyEngine = economyFactory.CreateEngine();

        IVehicleFactory luxuryFactory = new LuxuryCarFactory();
        ICar luxuryCar = luxuryFactory.CreateCar();
        IEngine luxuryEngine = luxuryFactory.CreateEngine();

        Console.WriteLine("Economy Car:");
        economyCar.Drive();
        economyEngine.Start();

        Console.WriteLine("\nLuxury Car:");
        luxuryCar.Drive();
        luxuryEngine.Start();
    }
}
