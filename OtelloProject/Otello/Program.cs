using System;
using System.Text;
using System.Threading.Tasks;

namespace OthelloPrototype
{
    // The Game class is the main orchestrator.
    public class Game
    {
        private readonly Board _board;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        private IPlayer _currentPlayer;

        // Action delegates for events
        public event Action<Board> OnBoardUpdated;
        public event Action<string> OnGameMessage;

        public Game(IPlayer player1, IPlayer player2, Board board)
        {
            _player1 = player1;
            _player2 = player2;
            _board = board;

            // Black always goes first
            _currentPlayer = _player1.Color == DiscColor.Black ? _player1 : _player2;
        }

        public async Task RunGame()
        {
            _board.Initialize();
            OnBoardUpdated?.Invoke(_board); // Fire event for initial state

            bool player1Passed = false;
            bool player2Passed = false;

            while (true)
            {
                // 1. Get move from current player
                Move move = await _currentPlayer.GetMoveAsync(_board);

                if (move == null)
                {
                    // Player must pass
                    OnGameMessage?.Invoke($"Player {_currentPlayer.Color} passes.");
                    if (_currentPlayer == _player1) player1Passed = true;
                    if (_currentPlayer == _player2) player2Passed = true;
                }
                else
                {
                    // Player made a move
                    if (_currentPlayer == _player1) player1Passed = false;
                    if (_currentPlayer == _player2) player2Passed = false;

                    // 2. Apply the valid move
                    _board.SetCell(move.Row, move.Column, _currentPlayer.Color);
                    foreach (var cellToFlip in move.FlippableCells)
                    {
                        _board.SetCell(cellToFlip.Row, cellToFlip.Col, _currentPlayer.Color);
                    }
                }
                
                // 3. Fire event to notify subscribers (the console UI)
                OnBoardUpdated?.Invoke(_board);

                // 4. Check for Game Over condition (both players passed)
                if (player1Passed && player2Passed)
                {
                    OnGameMessage?.Invoke("Both players passed. Game Over!");
                    break;
                }

                // 5. Swap turns
                SwitchTurn();
            }

            AnnounceWinner();
        }

        private void SwitchTurn()
        {
            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }
        
        private void AnnounceWinner()
        {
            int blackScore = 0;
            int whiteScore = 0;
            for(int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (_board.GetCell(r,c).Color == DiscColor.Black) blackScore++;
                    if (_board.GetCell(r,c).Color == DiscColor.White) whiteScore++;
                }
            }
            OnGameMessage?.Invoke($"Final Score: Black-{blackScore} | White-{whiteScore}");
            if (blackScore > whiteScore) OnGameMessage?.Invoke("Black wins!");
            else if (whiteScore > blackScore) OnGameMessage?.Invoke("White wins!");
            else OnGameMessage?.Invoke("It's a draw!");
        }
    }

    // Program class is the entry point and Console UI
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 1. Create all the dependencies
            var board = new Board();
            var validator = new StandardOthelloValidator();
            var player1 = new HumanPlayer(DiscColor.Black, validator);
            var player2 = new HumanPlayer(DiscColor.White, validator);

            // 2. Inject dependencies into the Game
            var game = new Game(player1, player2, board);

            // 3. Subscribe to events to create the UI
            game.OnBoardUpdated += PrintBoard;
            game.OnGameMessage += (message) => 
            {
                Console.WriteLine(message);
            };

            // 4. Run the game
            await game.RunGame();
        }

        // This is our "View" method
        private static void PrintBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("  0 1 2 3 4 5 6 7"); // Header
            var sb = new StringBuilder();
            for (int r = 0; r < 8; r++)
            {
                sb.Append(r); // Row number
                for (int c = 0; c < 8; c++)
                {
                    sb.Append(' ');
                    var color = board.GetCell(r, c).Color;
                    switch (color)
                    {
                        case DiscColor.None:
                            sb.Append('.'); // Empty
                            break;
                        case DiscColor.Black:
                            sb.Append('B'); // Black
                            break;
                        case DiscColor.White:
                            sb.Append('W'); // White
                            break;
                    }
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}