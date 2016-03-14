using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var game = new ChessGameEngine();

            Console.ReadKey();

            

            while (game.GameCode == 0)
            {
                game.Turn();

                Console.WriteLine();
                Console.WriteLine("     Press any key to initiate next turn");
                
               
            }
        }
    }
}
