using System.Collections.Generic;

namespace OthelloPrototype
{
    // Encapsulates the 8x8 grid.
    public class Board
    {
        private readonly Cell[,] _cells = new Cell[8, 8];

        public Board()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    _cells[r, c] = new Cell(r, c);
                }
            }
        }

        // Sets up the starting Othello position
        public void Initialize()
        {
            SetCell(3, 3, DiscColor.White);
            SetCell(3, 4, DiscColor.Black);
            SetCell(4, 3, DiscColor.Black);
            SetCell(4, 4, DiscColor.White);
        }

        public Cell GetCell(int r, int c)
        {
            if (r < 0 || r >= 8 || c < 0 || c >= 8)
                return null; // Out of bounds
            return _cells[r, c];
        }

        public void SetCell(int r, int c, DiscColor color)
        {
            if (r >= 0 && r < 8 && c >= 0 && c < 8)
            {
                _cells[r, c].Color = color;
            }
        }

        // This is a key method: It uses the validator to find all legal moves
        // for a given player.
        public List<Move> GetValidMoves(DiscColor player, IMoveValidator validator)
        {
            var validMoves = new List<Move>();
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    // Check every single cell
                    var flippableCells = validator.GetFlippableCells(this, r, c, player);
                    if (flippableCells.Count > 0)
                    {
                        // If this move flips at least one piece, it's valid.
                        validMoves.Add(new Move(r, c, flippableCells));
                    }
                }
            }
            return validMoves;
        }
    }
}