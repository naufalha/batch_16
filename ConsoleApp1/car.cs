namespace cars
{
    public class car
    {
        public string model;
        public int year;
        public car(string model, int year)
        {
            this.model = model;
            this.year = year;
        }
        public void displayInfo()
        {
            System.Console.WriteLine("Model: " + model + ", Year: " + year);
        }

    }
}

namespace gay
{
    public class vehicle
    {
        public string type;
        public vehicle(string type)
        {
            this.type = type;
        }
        public void displayType()
        {
            System.Console.WriteLine("Type: " + type);
        }

    }               
}