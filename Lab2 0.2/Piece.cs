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
        public void MovePiece(int newPosX, int newPosY)
        {
            // sätter de nya kordinaterna efter flytt
            PosX = newPosX;
            PosY = newPosY;  
        }
        public virtual bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        { return false; }
        public virtual void CheckOpponentPieceInReach()
        { }
        public virtual bool IsSquereClear(int newPosX, int newPosY, Player currentPlayer)
        {
            /* Kontrollerar listan spelarens lista med pjäser, om den nya positionen matchar en position 
            som redan används av en medspelande pjäs returneras false */
                foreach (Piece piece in currentPlayer.Pieces)
                {
                    if (piece.PosX == newPosX && piece.PosY == newPosY)
                    {
                        return false;
                    }
                }

            return true;
        }
        
    }
}
