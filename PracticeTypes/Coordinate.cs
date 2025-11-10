namespace MyZooProject
{
    //step 5 Structs this gonna be coordinate struct
    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        // Constructor
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
        // struct can have methods
        public override string ToString()
        {
            return base.ToString();
        }
    }
}