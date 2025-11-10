using System.Security.Cryptography.X509Certificates;

namespace MyZooProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of Animal
            Animal lion = new Animal("Leo", "Lion", DietType.Carnivore);
            Console.WriteLine($"Animal Name: {lion.Name}, Species: {lion.Species}");
            lion.MakeSound("Roar");
            Console.WriteLine("diet type: " + lion.Diet);
            Console.WriteLine("___________________________________");
            Animal UnknownAnimal = new Animal("amba", "", DietType.Unknown);
            Console.WriteLine($"Animal Name: {UnknownAnimal.Name}, Species: {UnknownAnimal.Species}");
            UnknownAnimal.MakeSound("Am bat u kam");
            Console.WriteLine("diet type: " + UnknownAnimal.Diet);
            Console.WriteLine("___________________________________");
            Console.WriteLine("step2 inheritance and polymorphism");
            //create an instance of Lion
            Lion simba = new Lion("Simba");
            Console.WriteLine($"Lion Name: {simba.Name}, Species: {simba.Species}");
            simba.MakeSound("Roarrrr");
            simba.Prowl();
            Console.WriteLine(("diet type: " + simba.Diet));
            Console.WriteLine("___________________________________");
            Bird tweety = new Bird("Tweety");
            Console.WriteLine($"Bird Name: {tweety.Name}, Species: {tweety.Species}");
            tweety.MakeSound("Chirp Chirp");
            Console.WriteLine("diet type: " + tweety.Diet);

            Console.WriteLine("___________________________________");
            Console.WriteLine("step3 Interface implementation");
            //create a fish
            Fish Lele = new Fish("Lele");
            Console.WriteLine($"Fish Name: {Lele.Name}, Species: {Lele.Species}");
            Lele.MakeSound("Blub Blub");
            Lele.Move();
            Console.WriteLine("diet type: " + Lele.Diet);
            Console.WriteLine("___________________________________");
            Console.WriteLine("step5 Generic Collections");
            //make an enclosure for lions that only accepts Lion objects
            Enclosure<Lion> lionEnclosure = new Enclosure<Lion>();
            lionEnclosure.AddAnimal(simba);
            lionEnclosure.AddAnimal(new Lion("Nala"));


            //for the bird enclosure
            Enclosure<Bird> birdEnclosure = new Enclosure<Bird>();
            birdEnclosure.AddAnimal(tweety);

            //for the fish enclosure
            Enclosure<Fish> fishEnclosure = new Enclosure<Fish>();
            fishEnclosure.AddAnimal(Lele);
            //display animals in each enclosure
            lionEnclosure.DisplayAnimals();
            birdEnclosure.DisplayAnimals();
            fishEnclosure.DisplayAnimals();

            //feeding animal
            Console.WriteLine("___________________________________");
            Console.WriteLine("step6 Feeding Animals");
            FeedAnimal(simba);
            FeedAnimal(tweety);
            FeedAnimal(Lele);
            FeedAnimal(lion);
            FeedAnimal(UnknownAnimal);
            
        }
            public static void FeedAnimal(Animal animal)
            {
                switch (animal.Diet)
                {
                    case DietType.Carnivore:
                        Console.WriteLine($"{animal.Name} the {animal.Species} is being fed meat.");
                        break;
                    case DietType.Herbivore:
                        Console.WriteLine($"{animal.Name} the {animal.Species} is being fed plants.");
                        break;
                    case DietType.Omnivore:
                        Console.WriteLine($"{animal.Name} the {animal.Species} is being fed a mix of meat and plants.");
                        break;
                    default:
                        Console.WriteLine($"{animal.Name} the {animal.Species} has an unknown diet.");
                        break;
                }
            }

      
      

    
    }
}