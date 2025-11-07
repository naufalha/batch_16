namespace 

//interface implementation
public interface IHarvestable
{
    void Harvest();
    public class Cow { };
}
    
    public enum HarvestStatus
    {
        Ready,
        Overdue,
        NotReady
    }
//base class
public abstract class Animal
{

    //public propertys
    public Guid Id { get; set; } = Guid.NewGuid();
    //protected propertys accessible in sublcalsses
    protected float _weight;
    //ppublic property with privateset readonly access to external
    public string Name { get; private set; }
    //constructor
    public Animal(string name, float weight)
    {
        this.Name = name;
        this._weight = weight;
    }
    // abstract method to be implemented in subclasses
    public abstract void MakeSound();
    //virtual method have a default value but allow subclass to ovveride it
    public virtual string getDiet()
    {
        return "Unknown Diet";
    }
    //readonly property using the protected field
    public double weight => _weight;
    //the object type : all class inherit from system object so can to string override
    public override string ToString()
    {
        return $"{Name}(ID: {Id.ToString().Substring(0, 8)})";
    }



    
}
//subclassess
public class Cow : Animal , IHarvestable
{
    //properti sapi
    public struct MilkYield{ public int Liters;  public HarvestStatus Status; }
    public MilkYield CurrentMilkYield { get; set; } = new MilkYield { Liters = 0, Status = HarvestStatus.NotReady };

    //class spessific constructor calling base constructor
    public Cow(string name, float weight) : base(name, weight)
    {
    }

    //membutuhkan abstract method
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says Moo!");

    }
    //implemntasi interface method
    public void Harvest()
    {
        if (CurrentMilkYield.Status == HarvestStatus.Ready)
        {
            Console.WriteLine($"harvesting {Name}'s milk: {CurrentMilkYield.Liters} liters.");
            CurrentMilkYield = new MilkYield { Liters = 0, Status = HarvestStatus.NotReady };

        }
        else
        {
            Console.WriteLine($"{Name}'s milk is not ready for harvest.");
        }
    }
}