using System.Collections.Generic;

namespace OthelloPrototype
{
    // The contract for any class that can validate Othello moves.
    public interface IMoveValidator
    {
        // Checks a single cell to see if a move is valid.
        // If it is, returns the list of cells it would flip.
        // If not, returns an empty list.
        List<Cell> GetFlippableCells(Board board, int r, int c, DiscColor playerColor);
    }
}