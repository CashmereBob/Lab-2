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
            if (!MoveToThreatOpponentKing(currentPlayer, opponentPlayer))
            {
                bool validMove = false;

                foreach (Piece opponentPiece in opponentPlayer.Pieces)
                {
                    foreach (Piece ownPiece in currentPlayer.Pieces)
                    {
                        if (ownPiece.IsMoveValid(opponentPiece.PosX, opponentPiece.PosY, currentPlayer, opponentPlayer) && IsKingSafeAfterMove(opponentPiece.PosX, opponentPiece.PosY, ownPiece, currentPlayer, opponentPlayer))
                        {
                            validMove = true;
                            opponentPlayer.RemoveBeatenPiece(opponentPiece, ownPiece); // slår ut motståndarens pjäs
                            ownPiece.MovePiece(opponentPiece.PosX, opponentPiece.PosY); // Flyttar egen pjäs                  
                            break;
                        }
                    }
                    if (validMove) { break; }
                }
                if (!validMove) { RandomMove(currentPlayer, opponentPlayer); }
            }
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
                    if (piece.IsMoveValid(newX, newY, currentPlayer, opponentPlayer) && IsKingSafeAfterMove(newX, newY, piece, currentPlayer, opponentPlayer))
                    {
                        validMove = true;
                        piece.MovePiece(newX, newY); // flyttar egen pjäs
                        break;
                    }
                }

            }
     

        }

        public void MoveKing(Player currentPlayer, Player opponentPlayer)
        {
            // Lagrar kungen i variabel.
            Piece king = null;

            foreach (Piece ownPiece in currentPlayer.Pieces)
            {
                if (ownPiece.Type == "king") { king = ownPiece; }
            }

            // Plockar ut nuvarande Position och försöker flytta.
            int kingPosX = king.PosX;
            int kingPosY = king.PosY;


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (king.IsMoveValid(x, y, currentPlayer, opponentPlayer) && IsKingSafeAfterMove(x, y, king, currentPlayer, opponentPlayer)) { BeatIfColide(x, y, king, opponentPlayer); return; }
                }

            }

            Console.WriteLine();
            Console.WriteLine("{0} is checkmate, {1} is the the winner", currentPlayer.Color, opponentPlayer.Color);
            Console.ReadKey();
            
        }

        private void BeatIfColide(int posX, int posY, Piece ownPiece, Player opponentPlayer )
        {
            // Om tvångsflyttat pjäs (kung) koliderar med motståndare slås denna ut.

            foreach (Piece opponentPiece in opponentPlayer.Pieces)
            {
                if (opponentPiece.PosX == posX && opponentPiece.PosY == posY)
                {
                    opponentPlayer.RemoveBeatenPiece(opponentPiece, ownPiece); // slår ut motståndarens pjäs
                    break;
                }
            }

            ownPiece.MovePiece(posX, posY);// Flyttar egen pjäs  

        }

        private bool IsKingSafeAfterMove(int newPosX, int newPosY, Piece ownPiece, Player currentPlayer, Player opponentPlayer)
        {
            // kontrollerar så att kungen är safe efter att pjäsen flyttats innan en flytt görs.

            int oldPosX = ownPiece.PosX;
            int oldPosY = ownPiece.PosY;

            ownPiece.MovePiece(newPosX, newPosY);

            if (currentPlayer.IsKingSafe(currentPlayer, opponentPlayer))
            {
                ownPiece.MovePiece(oldPosX, oldPosY);
                return true;
            }
            else
            {
                ownPiece.MovePiece(oldPosX, oldPosY);
                return false;
            }


            
        }

        private bool MoveToThreatOpponentKing(Player currentPlayer, Player opponentPlayer)
        {

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    foreach (Piece ownPiece in currentPlayer.Pieces)
                    {
                        if (ownPiece.IsMoveValid(x,y,currentPlayer,opponentPlayer) && !IsKingSafeAfterMove(x,y,ownPiece,opponentPlayer,currentPlayer) && IsKingSafeAfterMove(x, y, ownPiece, currentPlayer, opponentPlayer) && !ownPiece.IsSquareThreaten(x,y,currentPlayer,opponentPlayer))
                        {
                            ownPiece.MovePiece(x, y);
                            BeatIfColide(x, y, ownPiece, opponentPlayer);
                            return true;
                        }
                    }
                }
            }

            return false;

            
        }
        
    }
}
