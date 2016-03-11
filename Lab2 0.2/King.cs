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
        }
        public override bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        {
            // Kontrollerar rörelser för kungen, får gå 1 steg åt alla håll och inte kollidera med egna pjäser.
            if (PosX > 0 && PosY > 0 && newPosX == PosX - 1 && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosX > 0 && newPosX == PosX - 1 && newPosY == PosY && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosX > 0 && PosY < 7 && newPosX == PosX - 1 && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosY > 0 && newPosX == PosX && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosY < 7 && newPosX == PosX && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosX < 7 && PosY > 0 && newPosX == PosX + 1 && newPosY == PosY - 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosX < 7 && newPosX == PosX + 1 && newPosY == PosY && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }
            if (PosX < 7 && PosY < 7 && newPosX == PosX + 1 && newPosY == PosY + 1 && IsSquereClear(newPosX, newPosY, currentPlayer) && !IsSquareThreaten(newPosX, newPosY, currentPlayer, opponentPlayer)) { return true; }

            return false;
        }
        

    }
}
