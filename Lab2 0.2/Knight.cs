using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Knight : Piece
    {
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
            /*if ( PosX > 0 && PosY > 1 && newPosX == PosX - 1 && newPosY == PosY - 2 && IsSquereClear(PosX - 1, PosY - 2, currentPlayer)) { return true; }
            if ( PosX > 1 && PosY > 0 && newPosX == PosX - 2 && newPosY == PosY - 1 && IsSquereClear(PosX - 2, PosY - 1, currentPlayer)) { return true; }
            if ( PosX > 1 && PosY < 7 && newPosX == PosX - 2 && newPosY == PosY + 1 && IsSquereClear(PosX - 2, PosY + 1, currentPlayer)) { return true; }
            if ( PosX > 0 && PosY < 7 && newPosX == PosX - 1 && newPosY == PosY + 2 && IsSquereClear(PosX - 1, PosY + 2, currentPlayer)) { return true; }
            if ( PosX < 7 && PosY > 1 && newPosX == PosX + 1 && newPosY == PosY - 2 && IsSquereClear(PosX + 1, PosY - 2, currentPlayer)) { return true; }
            if ( PosX < 6 && PosY > 0 && newPosX == PosX + 2 && newPosY == PosY - 1 && IsSquereClear(PosX + 2, PosY - 1, currentPlayer)) { return true; }
            if ( PosX < 6 && PosY < 7 && newPosX == PosX + 2 && newPosY == PosY + 1 && IsSquereClear(PosX + 2, PosY + 1, currentPlayer)) { return true; }
            if ( PosX < 7 && PosY < 6 && newPosX == PosX + 1 && newPosY == PosY + 2 && IsSquereClear(PosX + 1, PosY + 2, currentPlayer)) { return true; }
            return false;*/

            //Solution 2
            /*
            //private int[] xmove = { -1,  1, -2,  2, -2,  2, -1,  1}; // Solution 2 under class def
            //private int[] ymove = {  2,  2,  1,  1, -1, -1, -2, -2}; // Solution 2 under class def
            if (PosX == newPosX && PosY == newPosY) return false;

            for (int i = 0; i < xmove.Length; i++)
            {
                if (newPosX == PosX + xmove[i] && newPosY == PosY + ymove[i] && IsSquereClear(PosX + xmove[i], PosY + ymove[i], currentPlayer)) 
                {
                    return true;
                } 
            }

            return false;*/

            if (PosX == newPosX && PosY == newPosY) return false;

            int diffX = newPosX - PosX;
            int diffY = newPosY - PosY;

            if (Math.Abs(diffX) > 2 || Math.Abs(diffY) > 2) return false;
            if ((Math.Abs(diffX) == Math.Abs(diffY)) || PosX == newPosX || PosY == newPosY) return false;

            if (IsSquereClear(newPosX, newPosY, currentPlayer)) return true;

            return false;
        }
    }
}
