using System.Threading.Tasks;

namespace OthelloPrototype
{
    // The "contract" for any player (Human, AI, Network)
    public interface IPlayer
    {
        DiscColor Color { get; }

        // Asks the player for a move.
        // It's async to support AI calculation or network latency.
        // Returning 'null' means the player must pass.
        Task<Move> GetMoveAsync(Board board);
    }
}