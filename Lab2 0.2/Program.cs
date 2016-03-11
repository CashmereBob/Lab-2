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

            bool gameContinue = true;

            while (gameContinue)
            {
                game.Turn();

                Console.ReadKey();
            }
        }
    }
}
