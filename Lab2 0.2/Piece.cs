using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    abstract class Piece
    {
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public string Type { get; protected set; }
        public string Color { get; protected set; }
        public List<Piece> OpponentPiecesInReach { get; protected set; }
        public Piece (int posX, int posY, string color)
        {
            this.PosX = posX;
            this.PosY = PosY;
            this.Color = color;
        }
        public void MovePiece(Piece piece)
        {
            int newPosX;
            int newPosY;
        }
        public virtual bool IsMoveValid(int newPosX, int newPosY)
        { return false; }
        public virtual void CheckOpponentPieceInReach()
        { }
        public virtual void GetOpponentPieceInReach()
        { }
        
    }
}
