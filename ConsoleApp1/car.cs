using System.Runtime.CompilerServices;

namespace veichles
{
    public class Veichles
    {
        public string color;
        public int speed;
        public int shift;
        

    
        public Veichles(string color, int speed)
        {
            this.color = color;
            this.speed = speed;
                
        }
        public void Move()
        {
            System.Console.WriteLine($"The {color} veichle is moving at {speed} km/h");
            switch (speed)
            {
                case <= 0:
                    shift = 0;
                    Console.WriteLine("The veichle is stationary.Neutral gear engaged.");
                    break;
                case > 0 and <= 20:
                    shift = 1;
                    Console.WriteLine("First gear engaged.");
                    break;
                case > 20 and <= 40:
                    shift = 2;
                    Console.WriteLine("Second gear engaged.");
                    break;
                case > 40 and <= 60:
                    shift = 3;
                    Console.WriteLine("Third gear engaged.");
                    break;
                case > 60 and <= 80:
                    shift = 4;
                    Console.WriteLine("Fourth gear engaged.");
                    break;
                case > 80:
                    shift = 5;
                    Console.WriteLine("Fifth gear engaged.");
                    break;

            }
        }
        public virtual void Honk()
        {
            System.Console.WriteLine("Beep Beep!");
        }
        
        public float Run(int distance)
        {
            int _distance = distance;
            float time = _distance / speed;
            this.Move();
            return time;
            
        }

    }
    public class Car : Veichles
    {
        public string model;
        private string[] _itemsInTrunk = [];

    
        public Car(string color, int speed, string model) : base(color, speed)
        {
            this.model = model;
        }
        public override void Honk()
        {
            System.Console.WriteLine("Car Horn: beep beep beep!");
        }
        public void InputTrunk(string items)
        {
            _itemsInTrunk.Append(items);
        }
        public void OpenTrunk()
        {
            System.Console.WriteLine("Trunk contains: ");
            System.Console.WriteLine(_itemsInTrunk);
        }

        public string GetItemsInTrunk(int index)
        {
            return _itemsInTrunk[index];
        }
    }
    public class Bike : Veichles
    {
        public bool hasCarrier;
        private int _wheels = 2;

        public Bike(string color, int speed, bool hasCarrier) : base(color, speed)
        {
            this.hasCarrier = hasCarrier;
        }
        public override void Honk()
        {
            System.Console.WriteLine("Bike Bell: ding ding!");
        }
    }

}