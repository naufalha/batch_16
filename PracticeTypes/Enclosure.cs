using System.Collections.Generic;
using System;
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
        //nested types can also be defined within generic classes
        //its help to manage enclosure environment
        //private to restrict access from outside
        private class MaintenanceLog
        {
            public DateTime LastCleaned { get; set; }
            public string Notes { get; set; }
            public MaintenanceLog(DateTime date, string notes)
            {
                LastCleaned = DateTime.Now;
                Notes = notes;
            }

        }
        //a list to old the nested types
        private List<MaintenanceLog> logs = new List<MaintenanceLog>();
        //method to add maintenance log
        public void PerformMaintenance(string notes)
        {
            MaintenanceLog log = new MaintenanceLog(DateTime.Now, notes);
            logs.Add(log);
            Console.WriteLine($"Performed maintenance on {typeof(TAnimal).Name} enclosure at {log.LastCleaned}: {log.Notes}");
        }
        //method to display maintenance logs
        public void DisplayMaintenanceLogs()
        {
            Console.WriteLine($"===Maintenance Logs for {typeof(TAnimal).Name} Enclosure===");
            foreach (var log in logs)
            {
                Console.WriteLine($"- Last Cleaned: {log.LastCleaned}, Notes: {log.Notes}");
            }
        }
    }
}