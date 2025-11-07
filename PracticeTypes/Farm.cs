using System;
using System.Collections.Generic;

namespace FarmingSimulation
{
    // --- 1. Interface (Polymorphism & Capability) ---
    // Defines a capability contract that unrelated animals can implement.
    public interface IHarvestable
    {
        // Must contain only signatures
        void Harvest();
    }

    // --- 2. Enum (Named Constants) ---
    // Represents a finite set of clear, type-safe choices.
    public enum HarvestStatus
    {
        Ready,
        Overdue,
        NeedsTime // Corrected the name from NotReady/NeedsTime ambiguity
    }

    // --- 3. Base Class (Inheritance & Abstraction) ---
    // Base class should be abstract as we never intend to instantiate a generic 'Animal'.
    public abstract class Animal
    {
        // Public property with a read-only init accessor (Immutability after construction).
        public Guid Id { get; init; } = Guid.NewGuid();

        // Protected field: Accessible by subclasses but not external code.
        // Changed type to double (C# best practice for general floating point numbers)
        protected double _weightInKg;

        // Public property with private set (read-only access to external consumers)
        public string Name { get; private set; }

        // Constructor to set required base properties (Type changed to double)
        public Animal(string name, double weightInKg)
        {
            Name = name;
            _weightInKg = weightInKg;
        }

        // Abstract Method: MUST be implemented by all non-abstract derived classes.
        public abstract void MakeSound();

        // Virtual Method: Provides a default, but allows subclasses to override.
        public virtual string GetDiet()
        {
            return "Unknown Diet";
        }

        // Example of a read-only property using the protected field.
        public double Weight => _weightInKg;

        // The Object Type: All classes inherit from System.Object, so we can override ToString()
        public override string ToString()
        {
            return $"{Name} (ID: {Id.ToString().Substring(0, 8)})";
        }
    }

    // --- 4. Subclasses (Inheritance & Implementation) ---

    public class Cow : Animal, IHarvestable
    {
        // Cow-specific property (using a struct for simple data)
        public struct MilkYield { public int Liters; public HarvestStatus Status; }
        public MilkYield CurrentYield { get; set; } = new MilkYield { Liters = 0, Status = HarvestStatus.NeedsTime };

        // Class-specific constructor calling the base constructor (Type changed to double)
        public Cow(string name, double weight) : base(name, weight) { }

        // Required implementation of the abstract method
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} mooed loudly!");
        }

        // Implementation of the interface method
        public void Harvest()
        {
            if (CurrentYield.Status == HarvestStatus.Ready)
            {
                Console.WriteLine($"--- Harvesting {Name}'s milk: 15L produced. ---");
                CurrentYield = new MilkYield { Liters = 0, Status = HarvestStatus.NeedsTime };
            }
            else
            {
                Console.WriteLine($"{Name}'s milk is not ready for harvest.");
            }
        }
    }

    public class Chicken : Animal, IHarvestable
    {
        // Chicken-specific property (using a struct for simple data)
        public struct EggYield { public int Count; public HarvestStatus Status; }
        public EggYield CurrentYield { get; set; } = new EggYield { Count = 0, Status = HarvestStatus.NeedsTime };

        // Class-specific constructor calling the base constructor (Type changed to double)
        public Chicken(string name, double weight) : base(name, weight) { }

        // Required implementation of the abstract method
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says cluck-cluck.");
        }

        // Overriding the virtual method from the base class
        public override string GetDiet()
        {
            return "Omnivore (Grains and Bugs)";
        }

        // Implementation of the interface method
        public void Harvest()
        {
            if (CurrentYield.Status == HarvestStatus.Ready)
            {
                Console.WriteLine($"--- Harvesting {Name}'s eggs: 12 eggs collected. ---");
                CurrentYield = new EggYield { Count = 0, Status = HarvestStatus.NeedsTime };
            }
            else
            {
                Console.WriteLine($"{Name}'s eggs are not ready for harvest.");
            }
        }
    }

    // --- 5. Generics & Nested Types ---

    // Generic Class: Works with any type T that is an Animal.
    public class FarmEnclosure<T> where T : Animal
    {
        // Nested Type: Class defined within another class for tight coupling (low scope)
        public class EnclosureReport
        {
            public int Count;
            public Type AnimalType;
        }

        private List<T> Animals = new List<T>();

        public void AddAnimal(T animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"- Added {animal.Name} to the {typeof(T).Name} enclosure.");
        }

        public void CheckStatus()
        {
            Console.WriteLine($"\n--- Enclosure Report for {typeof(T).Name}s ---");
            foreach (var animal in Animals)
            {
                Console.WriteLine($"{animal} | Weight: {animal.Weight}kg | Diet: {animal.GetDiet()}");

                // Check if the animal is harvestable using the 'is' keyword (Polymorphism)
                if (animal is IHarvestable harvestable)
                {
                    harvestable.Harvest(); // Call the Harvest method defined in the interface
                }
            }
        }

        public EnclosureReport GenerateReport()
        {
            return new EnclosureReport
            {
                Count = Animals.Count,
                AnimalType = typeof(T)
            };
        }   

        
    }
}
