using System;

namespace BoardExample
{
    // Generic 8x8 board
    public class Board<T>
    {
        public const int Rows = 8;
        public const int Cols = 8;
        private readonly T[,] _grid;

        public Board()
        {
            _grid = new T[Rows, Cols];
        }

        // Indexer
        public T this[int row, int col]
        {
            get
            {
                Validate(row, col);
                return _grid[row, col];
            }
            set
            {
                Validate(row, col);
                _grid[row, col] = value;
            }
        }

        // Clear the board by setting default(T)
        public void Clear()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    _grid[r, c] = default!;
        }

        // Fill with a value
        public void Fill(T value)
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    _grid[r, c] = value;
        }

        // Simple console printer. Provide a formatter for custom representation.
        public void PrintConsole(Func<T, string>? formatter = null)
        {
            formatter ??= (v => v?.ToString() ?? ".");
            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int r = 0; r < Rows; r++)
            {
                Console.Write(r + " ");
                for (int c = 0; c < Cols; c++)
                {
                    string s = formatter(_grid[r, c]);
                    // keep cell width to 1 char if possible, or pad/truncate
                    if (s.Length == 0) s = ".";
                    Console.Write(s[0] + " ");
                }
                Console.WriteLine();
            }
        }

        // Validate coordinates
        private static void Validate(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new IndexOutOfRangeException($"Coordinates out of range: ({row},{col})");
        }
    }

    // Example usage
    class Program
    {
        static void Main()
        {
            // Example 1: simple char board (like chessboard visual)
            var charBoard = new Board<char>();
            charBoard.Fill('.');            // default empty cell character
            charBoard[0, 0] = 'R';         // place a rook (example)
            charBoard[0, 1] = 'N';         // knight
            charBoard[7, 7] = 'K';         // king

            Console.WriteLine("Char board:");
            charBoard.PrintConsole(ch => ch == '\0' ? "." : ch.ToString());

            // Example 2: bool board (like visited cells)
            var visited = new Board<bool>();
            visited.Clear();
            visited[3, 4] = true;
            Console.WriteLine("\nVisited board (1 = true, . = false):");
            visited.PrintConsole(b => b ? "1" : ".");

            // Example 3: enum pieces for a game
            var pieceBoard = new Board<Piece>();
            pieceBoard.Fill(Piece.None);
            pieceBoard[3, 3] = Piece.Black;
            pieceBoard[4, 4] = Piece.White;
            Console.WriteLine("\nPiece board:");
            pieceBoard.PrintConsole(p => p switch
            {
                Piece.None => ".",
                Piece.Black => "B",
                Piece.White => "W",
                _ => "?"
            });
        }
    }

    enum Piece
    {
        None,
        White,
        Black
    }
}
