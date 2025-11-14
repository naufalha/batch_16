using System.Collections.Generic;

namespace OthelloPrototype
{
    // Represents a single, validated move.
    // It's created by the validator and used by the player and game.
    public class Move
    {
        public int Row { get; }
        public int Column { get; }
        
        // The list of opponent pieces that this move will flip.
        public List<Cell> FlippableCells { get; }

        public Move(int row, int column, List<Cell> flippableCells)
        {
            Row = row;
            Column = column;
            FlippableCells = flippableCells;
        }

        // For display in the console
        public override string ToString()
        {
            return $"({Row}, {Column})";
        }
    }
}