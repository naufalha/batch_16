namespace MyZooProject
{
    public class Animal
    {
        //privaete fields
        // Class implementation goes here
        private string _species;
        public string Name { get; set; }
        public String Species
        {
            get
            {
                return _species;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _species = "Unknown Species";
                }
                else
                {
                    _species = value;
                }
            }
        }
        public DietType Diet { get; set; }
        //constructor
        public Animal(string name, string species, DietType diet )
        {
            Console.WriteLine("An animal has been created.");
            Name = name;
            Species = species;
            Diet = diet;
        
        }
        //methods
        public virtual void MakeSound(string sound)
        {
            Console.WriteLine($"{Name} makes a sound.,the species is {Species} says {sound}");
        }
        //method feeding animal base  of diet type enum
        public void FeedAnimal(Animal animal)
        {
            switch (animal.Diet)
            {
                case DietType.Carnivore:
                    Console.WriteLine($"{animal.Name} the {animal.Species} is eating meat.");
                    break;
                case DietType.Herbivore:
                    Console.WriteLine($"{animal.Name} the {animal.Species} is eating plants.");
                    break;
                case DietType.Omnivore:
                    Console.WriteLine($"{animal.Name} the {animal.Species} is eating both meat and plants.");
                    break;
                default:
                    Console.WriteLine($"{animal.Name} the {animal.Species} has an unknown diet.");
                    break;
            }
        }
    }
    public class Lion : Animal
    {
        //lion constructor using base class constructor
        public Lion(string name) : base(name, "Lion", DietType.Carnivore)
        {
            Console.WriteLine("A lion has been created.");
        }
        // override MakeSound method
        public override void MakeSound(string sound)
        {
            Console.WriteLine($"{Name} the {Species} roars: {sound}");
        }
        // additional method specific to Lion
        public void Prowl()
        {
            Console.WriteLine($"{Name} is prowling in the savannah.");
        }
    }

    public class Bird : Animal
    {
        //bird constructor using base class constructor 
        public Bird(string name) : base(name, "Bird",DietType.Omnivore)
        {
            Console.WriteLine("A bird has been created.");
        }
        //override MakeSound method
        public override void MakeSound(string sound)
        {
            Console.WriteLine($"{Name} the {Species} chirps: {sound}");
        }
        //additional method specific to Bird
        public void Fly()
        {
            Console.WriteLine($"{Name} is flying in the sky.");
        }

    }
    public class Fish : Animal, IMoveable
    {
        //fish constructor using base class constructor
        public Fish(string name) : base(name, "Fish", DietType.Omnivore)
        {
            Console.WriteLine("A fish has been created.");
        }
        //override MakeSound method
        public override void MakeSound(string sound)
        {
            Console.WriteLine($"{Name} the {Species} makes bubbles: Blub Blub");

        }
        //implementation of IMoveable interface method
        public void Move()
        {
            Console.WriteLine($"{Name} is swimming in the water.");
        }
    }
}