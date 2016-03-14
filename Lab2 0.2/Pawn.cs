using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Pawn : Piece
    {
        public Pawn(int posX, int posY, string color) : base (posX, posY, color)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Color = color;
            this.Type = "pawn";
            this.Points = 1;
        }

        public override bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        {
            // Sätter värden för start rad och riktning av steg eftersom pawns bara får gå åt ett håll

            int startingRow = -10;
            int endRow = -10;
            int oneStep = -10;
            int twoStep = -10;

            if (Color == "white")
            {
                startingRow = 1;
                endRow = 7;
                oneStep = 1;
                twoStep = 2;
 
            }
            else if (Color == "black")
            {
                startingRow = 6;
                endRow = 0;
                oneStep = -1;
                twoStep = -2;
            }

            // Samtliga kontroller kontrollerar om "IsSquereClear" mot både egna och motståndarens pjäser.

            // Kontrollerar om pawn står på första raden, har då möjlighet att flytta 1 eller 2 steg.
            if (PosX == startingRow && PosY == newPosY)
            {
                if (newPosX == PosX + oneStep && IsSquereClear(PosX + oneStep, PosY, currentPlayer) && IsSquereClear(PosX + oneStep, PosY, opponentPlayer)) { return true; }
                if (newPosX == PosX + twoStep && IsSquereClear(PosX + twoStep, PosY, currentPlayer) && IsSquereClear(PosX + twoStep, PosY, opponentPlayer)) { return true; }
            }

            // Kontrollerar så att pawn inte står på sista raden.
            if (PosX != endRow)
            {
                // Vanligt steg fram, kontrollerar så att steget fortfarande är i samma kolumn.
                if (newPosX == PosX + oneStep && newPosY == PosY && IsSquereClear(PosX + oneStep, PosY, currentPlayer) && IsSquereClear(PosX + oneStep, PosY, opponentPlayer)) { return true; }

                // Kontrollerar om pawn har motståndare snett framför sig är detta steget accepterat.
                if (PosY < 7 && newPosX == PosX + oneStep && newPosY == PosY + 1 && IsSquereClear(PosX + oneStep, PosY + 1, currentPlayer) && !IsSquereClear(PosX + oneStep, PosY + 1, opponentPlayer)) { return true; }
                if (PosY > 0 && newPosX == PosX + oneStep && newPosY == PosY - 1 && IsSquereClear(PosX + oneStep, PosY - 1, currentPlayer) && !IsSquereClear(PosX + oneStep, PosY + 1, opponentPlayer)) { return true; }
            }

            return false;
        }

    }
}
