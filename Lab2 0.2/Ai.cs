using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Ai
    {
        public void CalculateBestMove(Player currentPlayer, Player opponentPlayer)
        {
            /* Loopar igenom motståndarens pjäser för att se om någon av dessa går att slå av egna pjäser
            genom att för varje motståndar pjäs kontrollera om dess kordinater är ett valid move av egna pjäser.
            Om det inte finns några tillgängliga pjäser att slå avslutas metoden med att kalla på random move*/
            bool validMove = false;

            foreach (Piece opponentPiece in opponentPlayer.Pieces)
            {
                foreach (Piece ownPiece in currentPlayer.Pieces)
                {
                    if (ownPiece.IsMoveValid(opponentPiece.PosX, opponentPiece.PosY, currentPlayer, opponentPlayer))
                    {
                        validMove = true;
                        ownPiece.MovePiece(opponentPiece.PosX, opponentPiece.PosY); // Flyttar egen pjäs
                        opponentPlayer.RemoveBeatenPiece(opponentPiece, ownPiece); // slår ut motståndarens pjäs
                        break;
                    }
                }
                if (validMove) { break; }    
            }
            if (!validMove) { RandomMove(currentPlayer, opponentPlayer); }
        }
        public void RandomMove(Player currentPlayer, Player opponentPlayer)
        {
            /* generera fram slumpade kordinater mellan 0 och 7. Dessa testas sedan för valid move genom
            att loopa igenom alla tillgängliga spelarpjäser. Detta sker tills en valid move har inträffat */

            bool validMove = false;
            while (!validMove)
            {
                Random random = new Random();
                int newX = random.Next(8);
                int newY = random.Next(8);

                foreach (Piece piece in currentPlayer.Pieces)
                {
                    if (piece.IsMoveValid(newX, newY, currentPlayer, opponentPlayer))
                    {
                        validMove = true;
                        piece.MovePiece(newX, newY); // flyttar egen pjäs
                        break;
                    }
                }

            }
     

        }
    }
}
