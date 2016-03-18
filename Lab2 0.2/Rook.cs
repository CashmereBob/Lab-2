using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    public class Rook : Piece
    {
        public Rook(int posX, int posY, string color) : base(posX, posY, color)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Color = color;
            this.Type = "rook";
            this.Points = 5;
        }

        public override bool IsMoveValid(int newPosX, int newPosY, Player currentPlayer, Player opponentPlayer)
        {
            if (PosX == newPosX && PosY == newPosY) return false;
            if (!(PosX == newPosX || PosY == newPosY)) return false;
            
            int dx = Math.Max(-1, Math.Min(1, newPosX - PosX));
            int dy = Math.Max(-1, Math.Min(1, newPosY - PosY));

            int x = PosX + dx;
            int y = PosY + dy;
            for (; x != newPosX || y != newPosY; x += dx, y += dy)
            {
                if (!IsSquereClear(x, y, currentPlayer) || !IsSquereClear(x, y, opponentPlayer))
                {
                    return false;
                }
            }

            if (!IsSquereClear(x, y, currentPlayer))
            {
                return false;
            }
            return true;
        }
    }
}
