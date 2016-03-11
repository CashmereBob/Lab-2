using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Board
    {
        public Piece[,] GameBoard { get; private set; }

        public Board()
        {
            GameBoard = new Piece[8, 8];
        }
        public void UppdatePlayerPiecesOnBoard(Player currentPlayer, Player opponentPlayer)
        {
            // Rensar brädet från föregående runda
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    GameBoard[x, y] = null;
                }
            }

            // Lägger in Nuvarende spelares pjäser på brädet
            foreach (Piece piece in currentPlayer.Pieces)
            {
                GameBoard[piece.PosX, piece.PosY] = piece;
            }

            // Lägger in motståndarens pjäser på brädet
            foreach (Piece piece in opponentPlayer.Pieces)
            {
                GameBoard[piece.PosX, piece.PosY] = piece;
            }
        }
    }
}
