using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Knight : Piece
    {
        //int[] xmove = { -1,  1, -2,  2, -2,  2, -1,  1}; //Improvment later
        //int[] ymove = {  2,  2,  1,  1, -1, -1, -2, -2};

        public Knight(int posX, int posY, string color) : base (posX, posY, color)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Color = color;
            this.Type = "knight";
            this.Points = 3;
        }
        public override bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        {
            // Knight hopp, kontrollerar om det finns egen spelare på mål position om inte valid move
            if ( PosX > 0 && PosY > 1 && newPosX == PosX - 1 && newPosY == PosY - 2 && IsSquereClear(PosX - 1, PosY - 2, currentPlayer)) { return true; }
            if ( PosX > 1 && PosY > 0 && newPosX == PosX - 2 && newPosY == PosY - 1 && IsSquereClear(PosX - 2, PosY - 1, currentPlayer)) { return true; }
            if ( PosX > 1 && PosY < 7 && newPosX == PosX - 2 && newPosY == PosY + 1 && IsSquereClear(PosX - 2, PosY + 1, currentPlayer)) { return true; }
            if ( PosX > 0 && PosY < 7 && newPosX == PosX - 1 && newPosY == PosY + 2 && IsSquereClear(PosX - 1, PosY + 2, currentPlayer)) { return true; }
            if ( PosX < 7 && PosY > 1 && newPosX == PosX + 1 && newPosY == PosY - 2 && IsSquereClear(PosX + 1, PosY - 2, currentPlayer)) { return true; }
            if ( PosX < 6 && PosY > 0 && newPosX == PosX + 2 && newPosY == PosY - 1 && IsSquereClear(PosX + 2, PosY - 1, currentPlayer)) { return true; }
            if ( PosX < 6 && PosY < 7 && newPosX == PosX + 2 && newPosY == PosY + 1 && IsSquereClear(PosX + 2, PosY + 1, currentPlayer)) { return true; }
            if ( PosX < 7 && PosY < 6 && newPosX == PosX + 1 && newPosY == PosY + 2 && IsSquereClear(PosX + 1, PosY + 2, currentPlayer)) { return true; }




            return false;
        }
    }
}
