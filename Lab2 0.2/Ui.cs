using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Ui
    {
        public void PrintBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("        1     2     3     4     5     6     7     8");
            Console.WriteLine("     -------------------------------------------------");
            for (int x = 0; x < 8; x++)
            {
                Console.Write("  ");
                Console.Write(x + 1);
                Console.Write("  ");
                Console.Write("|");

                for (int y = 0; y < 8; y++)
                {
                    
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
                    Console.Write("|");
                }

                Console.Write("\n");
                Console.Write("     -------------------------------------------------");
                Console.Write("\n");
            }

        }
    }
}
