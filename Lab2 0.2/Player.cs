using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Player
    {
        public List<Piece> Pieces { get; private set; }
        public string Color { get; private set; }

        public Player(string color)
        {
            Color = color;
            InitiatePieces();
        }

        public void InitiatePieces()
        {
            
        }

        public void RemoveBeatenPiece(Piece piece)
        {

        }

        public bool IsKingSafe()
        {
            return true;
        }

    }
}
