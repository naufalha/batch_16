using FarmingSimulation;
using System;
// The Program entry point
class Program
{
    static void Main(string[] args)
    {
        // Example usage of the defined types
        Console.WriteLine("Farming Simulation Started.");

        // Since Animal is abstract, we cannot instantiate it directly.
        // We would typically create derived classes like Cow, Chicken, etc.

        Cow Ambatukam = new Cow("Ambatukam", 700);
        Ambatukam.MakeSound();
        Ambatukam.CurrentYield = new Cow.MilkYield { Liters = 20, Status = HarvestStatus.Ready };
        Ambatukam.Harvest();

        Chicken Rusdi = new Chicken("Rusdi", 5);
        Rusdi.MakeSound();
        Rusdi.CurrentYield = new Chicken.EggYield { Count = 12, Status = HarvestStatus.Ready };
        Rusdi.Harvest();

        Cow Fuad = new Cow("Fuad", 680);
        Cow Budi = new Cow("Budi", 720);
        Chicken Ani = new Chicken("Ani", 4);
        Chicken Sari = new Chicken("Sari", 6);
        Cow Dodi = new Cow("Dodi", 690);
        Chicken Rina = new Chicken("Rina", 5);
    


        //report
        FarmEnclosure<Cow> cowEnclosure = new FarmEnclosure<Cow>();

        FarmEnclosure<Chicken> chickenEnclosure = new FarmEnclosure<Chicken>();

        Console.WriteLine(cowEnclosure.GenerateReport());
        Console.WriteLine(chickenEnclosure.GenerateReport());



    }


}