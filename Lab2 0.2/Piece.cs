using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    interface Piece
    {
        int PosX { get; }
        int PosY { get; }
        string Type { get; }
        string Color { get; }
        List<Piece> OpponentPiecesInReach { get; }
        void Piece(int posX, int posY, string color);
        void MovePiece(int newPosX, int newPosY);
        bool IsMoveValid(int newPosX, int newPosY);
        void CheckOpponentPieceInReach();
        void GetOpponentPieceInReach();
        
    }
}
