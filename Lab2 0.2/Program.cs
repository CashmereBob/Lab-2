using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var game = new ChessGameEngine();

            

            while (true)
            {
                
                game.Turn();
                Console.Clear();
                // Skriver ut spelbrädet
                game._ui.PrintBoard(game._gameboard);
                Console.WriteLine();
                Console.WriteLine("Press any key to initiate next turn");
                Console.ReadKey();
                
               
            }
        }
    }
}
