using veichles;
class Program
{
    static void Main(string[] args)

    {
        Car myCar = new Car("Red", 10, "Toyota");
        myCar.Move();
        myCar.Honk();

        Bike myBike = new Bike("Blue", 30, true);
        myBike.Move();
        myBike.Honk();

        /* correcting car speed, running 100km in one hour
        while (myCar.Run(100) >= 1)
        {
            myCar.speed += 1;
            Console.WriteLine($"Car speed increased to: {myCar.speed} km/h");
            Thread.Sleep(500);
        }
        Console.WriteLine($"Car reached the destination in: 1 hours");
        */
        myCar.InputTrunk("books");
        myCar.InputTrunk("laptop");
        myCar.OpenTrunk();
        var allItemInTrunk = myCar.GetAllItemsInTrunk();

        foreach (var item in allItemInTrunk)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine($"First item in trunk: {myCar.GetItemsInTrunk(0)}");
   
        Console.ReadKey();
    }

}
