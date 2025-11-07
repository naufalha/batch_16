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
        Cow Eko = new Cow("Eko", 710);
        Chicken Tini = new Chicken("Tini", 4);


        Fuad.CurrentYield = new Cow.MilkYield { Liters = 18, Status = HarvestStatus.Ready };
        Budi.CurrentYield = new Cow.MilkYield { Liters = 22, Status = HarvestStatus.NeedsTime };
        Ani.CurrentYield = new Chicken.EggYield { Count = 10, Status = HarvestStatus.Ready };
        Sari.CurrentYield = new Chicken.EggYield { Count = 14, Status = HarvestStatus.NeedsTime };


        //report
        FarmEnclosure<Cow> cowEnclosure = new FarmEnclosure<Cow>();

        FarmEnclosure<Chicken> chickenEnclosure = new FarmEnclosure<Chicken>();

        cowEnclosure.AddAnimal(Ambatukam);
        cowEnclosure.AddAnimal(Fuad);
        cowEnclosure.AddAnimal(Budi);
        cowEnclosure.AddAnimal(Dodi);
        cowEnclosure.AddAnimal(Eko);
        chickenEnclosure.AddAnimal(Rusdi);
        chickenEnclosure.AddAnimal(Ani);
        chickenEnclosure.AddAnimal(Sari);
        chickenEnclosure.AddAnimal(Rina);
        chickenEnclosure.AddAnimal(Tini);

        cowEnclosure.CheckStatus();
        chickenEnclosure.CheckStatus(); 


        Console.WriteLine(cowEnclosure.GenerateReport());
        Console.WriteLine(chickenEnclosure.GenerateReport());



    }


}