using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Board
    {
        public Piece[,] GameBoard { get; private set; }

        public Board()
        {
            GameBoard = new Piece[8, 8];
        }
        public void UppdatePlayerPiecesOnBoard(Player player)
        {

        }
    }
}
