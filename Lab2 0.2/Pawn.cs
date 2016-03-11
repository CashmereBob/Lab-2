using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Pawn : Piece
    {
        private int _posX;
        private int _posY;
        private string _type;
        private string _color;
        private List<Piece> _opponentPiecesInReach;
        public List<Piece> OpponentPiecesInReach
        {
            get
            {
                return _opponentPiecesInReach;
            }
        }

        public int PosX
        {
            get
            {
                return _posX;
            }
        }

        public int PosY
        {
            get
            {
                return _posY;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
        }
        public void Piece(int posX, int posY, string color)
        {
            _posX = posX;
            _posY = posY;
            _color = color;
            _type = "pawn";
        }
        public void CheckOpponentPieceInReach()
        {
            throw new NotImplementedException();
        }

        public void GetOpponentPieceInReach()
        {
            throw new NotImplementedException();
        }

        public bool IsMoveValid(int newPosX, int newPosY)
        {
            throw new NotImplementedException();
        }

        public void MovePiece(int newPosX, int newPosY)
        {
            throw new NotImplementedException();
        }

    }
}
