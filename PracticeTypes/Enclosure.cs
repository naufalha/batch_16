using System.Collections.Generic;
namespace MyZooProject
{
    //step 5 : Generic Collections
    public class Enclosure<TAnimal> where TAnimal : Animal
    {
        //this type-safe list can only hold objects of type TAnimal
        private List<TAnimal> animals = new List<TAnimal>();
        //method to add an animal to the enclosure
        public void AddAnimal(TAnimal animal)
        {
            animals.Add(animal);
            Console.WriteLine($"Added {animal.Name} and species {animal.Species} to the enclosure.type of {typeof(TAnimal).Name},");
        }
        //method to display animals
        public void DisplayAnimals()
        {
            Console.WriteLine($"===Animals in {typeof(TAnimal).Name} Enclosure===");
            foreach (var animal in animals)
            {
                Console.WriteLine($"- {animal.Name} the {animal.Species}");
            }
        }
        //usage of struct Coordinates location
        public Location EnclosureLocation { get; set; }

    }
}