using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class King : Piece
    {
        public King(int posX, int posY, string color) : base (posX, posY, color)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Color = color;
            this.Type = "king";
            this.Points = 10;
        }
        public override bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        {
            // Kontrollerar rörelser för kungen, får gå 1 steg åt alla håll och inte kollidera med egna pjäser.
            /*if (PosX > 0 && PosY > 0 && newPosX == PosX - 1 && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosX > 0 && newPosX == PosX - 1 && newPosY == PosY && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosX > 0 && PosY < 7 && newPosX == PosX - 1 && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosY > 0 && newPosX == PosX && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosY < 7 && newPosX == PosX && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosX < 7 && PosY > 0 && newPosX == PosX + 1 && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosX < 7 && newPosX == PosX + 1 && newPosY == PosY && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }
            else if (PosX < 7 && PosY < 7 && newPosX == PosX + 1 && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer)) { return true; }

            return false;*/

            if (PosX == newPosX && PosY == newPosY) return false;

            int diffX = newPosX - PosX;
            int diffY = newPosY - PosY;

            if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1) return false;

            if (IsSquereClear(newPosX, newPosY, currentPlayer)) return true;

            return false;
        }
        

    }
}
