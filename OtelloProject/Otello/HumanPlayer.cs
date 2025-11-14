using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OthelloPrototype
{
    // Concrete implementation for a Human
    public class HumanPlayer : IPlayer
    {
        public DiscColor Color { get; }
        private readonly IMoveValidator _validator;

        public HumanPlayer(DiscColor color, IMoveValidator validator)
        {
            Color = color;
            _validator = validator; // Gets the validator injected
        }

        public Task<Move> GetMoveAsync(Board board)
        {
            // 1. Find all valid moves
            var validMoves = board.GetValidMoves(Color, _validator);

            // 2. Check for pass condition
            if (validMoves.Count == 0)
            {
                Console.WriteLine($"Player {Color} has no valid moves. Press Enter to pass.");
                Console.ReadLine();
                return Task.FromResult<Move>(null); // null means pass
            }

            // 3. List moves and ask user
            Console.WriteLine($"Player {Color}, your turn. Valid moves are:");
            for(int i = 0; i < validMoves.Count; i++)
            {
                Console.Write($" {i + 1}: {validMoves[i]} ");
            }
            Console.WriteLine();

            // 4. Loop until user gives valid input
            while (true)
            {
                Console.Write("Enter move number (e.g., '1'): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int moveIndex) && moveIndex > 0 && moveIndex <= validMoves.Count)
                {
                    // Return the chosen move
                    return Task.FromResult(validMoves[moveIndex - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
        }
    }
}