using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{

    public class Ui 
    {
        public string _latestMove { get; set; }
        private int _moveCounter = 1;

        public void PrintBoard(Board board)
        {
            ConsoleColor[] colors = { ConsoleColor.Gray, ConsoleColor.Black };

            
            Console.WriteLine();
            Console.WriteLine("        A     B     C     D     E     F     G     H");
            Console.WriteLine("     -------------------------------------------------");
            for (int x = 0; x < 8; x++)
            {
                Console.Write("  "); 
                Console.Write(x + 1);
                Console.Write("  ");
                Console.Write("|");

                for (int y = 0; y < 8; y++)
                {
                    Console.BackgroundColor = colors[(x + y) % 2];
                    Console.ForegroundColor = colors[(x + y + 1) % 2];

                    if (board.GameBoard[x,y] == null)
                    {
                        Console.Write("     ");
                    }
                    else
                    { 
                    StringBuilder newType = new StringBuilder();
                    newType.Append(board.GameBoard[x, y].Color[0]);
                    newType.Append(board.GameBoard[x, y].Type[0].ToString().ToUpper());
                    newType.Append(board.GameBoard[x, y].Type[1]);

                    string output = newType.ToString();
                    Console.Write(" " + output + " ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }

                Console.Write("\n");
                Console.Write("     -------------------------------------------------");
                Console.Write("\n");
                
            }
            Console.WriteLine(_latestMove);
        }

        public void LoggLatestMove(int oldPosX, int oldPosY, int newPosX, int newPosY, Piece ownPiece)
        {
            string column = "ABCDEFGH";
            _latestMove = string.Format($"#{_moveCounter}. {ownPiece.Color} {ownPiece.Type} from {column[oldPosY]}{oldPosX+1} to {column[newPosY]}{newPosX + 1}");
            _moveCounter++;
        }

        public void LoggBeat(Piece beatenPiece)
        {
            _latestMove += string.Format($" beats {beatenPiece.Color} {beatenPiece.Type}");
        }
        public void LoggCheck()
        {
            _latestMove += string.Format($" CHECK!");
        }

        public void LoggCheckMate(Player currentPlayer)
        {
            _latestMove += string.Format($" *CHECKMATE, GAME OVER!");
        }

        public void LoggDraw()
        {
            _latestMove = "No pawn moves or beats for 50 rounds. DRAW, GAME OVER!";
        }
    }
}
