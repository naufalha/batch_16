namespace OthelloPrototype
{
    public class Cell
    {
        public DiscColor Color { get; set;}
        public int Row{get;}
        public int Col{get;}

        public Cell(int row,int col)
        {
            Row = row;
            Col = col;
            Color = DiscColor.None;
        }
    }
}