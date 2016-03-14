using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Ai
    {
        public void CalculateBestMove(Player currentPlayer, Player opponentPlayer, int gameCode)
        {
            /* Loopar igenom motståndarens pjäser för att se om någon av dessa går att slå av egna pjäser
            genom att för varje motståndar pjäs kontrollera om dess kordinater är ett valid move av egna pjäser.
            Om det inte finns några tillgängliga pjäser att slå avslutas metoden med att kalla på random move


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
            }*/

            // key är en array på två där index 0 är X och index 1 är Y, Value är den pice som kan flytta dit.
            Dictionary<int[], Piece> safeMoves = new Dictionary<int[], Piece>();
            Dictionary<int[], Piece> unSafeMoves = new Dictionary<int[], Piece>();

            // Key är spelarens pjäs och value är den pjäs som spelaren kan klå med key pjäsen.
            Dictionary<Piece, Piece> safeBeatMoves = new Dictionary<Piece, Piece>();
            Dictionary<Piece, Piece> unSafeBeatMoves = new Dictionary<Piece, Piece>();

            //fyller listorna med moves.
            AddMovesToLists(safeMoves, unSafeMoves, safeBeatMoves, unSafeBeatMoves, currentPlayer, opponentPlayer);

            //Försöker först hota motståndarens kung om det inte går fortsätter metoden in i if satsen.
            if (!MoveToThreatOpponentKing(currentPlayer, opponentPlayer))
            {
                if (safeBeatMoves.Count() != 0)
                {
                    Piece ownPiece = null;
                    Piece opponentPiece = null;
                    foreach (KeyValuePair<Piece, Piece> move in safeBeatMoves)
                    {
                        if (opponentPiece == null)
                        {
                            ownPiece = move.Key;
                            opponentPiece = move.Value;
                        }
                        else
                        {
                            if (opponentPiece.Points < move.Value.Points)
                            {
                                ownPiece = move.Key;
                                opponentPiece = move.Value;
                            }
                        }
                    }

                    BeatIfColide(opponentPiece.PosX, opponentPiece.PosY, ownPiece, opponentPlayer);
                    return;
                } 
                else if (unSafeBeatMoves.Count() != 0)
                {

                    Dictionary<Piece, Piece> rankedMoves = new Dictionary<Piece, Piece>();

                    //Går igenom osäkra moves för att se om pjäsen spelaren offrar är värd mer än den spelaren tar.
                    foreach (KeyValuePair<Piece, Piece> move in unSafeBeatMoves)
                    {
                        // om egen pjäs är värd mer än motståndarens.
                        if (move.Key.Points > move.Value.Points)
                        {
                            // om egen pjäs redan är rankad
                            if (rankedMoves.ContainsKey(move.Key))
                            {
                                // Om rankad pjäs mål är värt mindre än det nya målet.
                                if (rankedMoves[move.Key].Points < move.Value.Points)
                                {
                                    rankedMoves[move.Key] = move.Value;
                                }
                            }
                            else
                            {
                                rankedMoves.Add(move.Key, move.Value);
                            }
                        }
                    }

                    if (rankedMoves.Count() != 0)
                    {
                        Piece ownPiece = null;
                        Piece opponentPiece = null;

                        foreach (KeyValuePair<Piece, Piece> move in rankedMoves)
                        {
                            if (opponentPiece == null)
                            {
                                ownPiece = move.Key;
                                opponentPiece = move.Value;
                            }
                            else
                            {
                                if (opponentPiece.Points < move.Value.Points && ownPiece.Points > move.Key.Points)
                                {
                                    ownPiece = move.Key;
                                    opponentPiece = move.Value;
                                }
                            }
                        }

                        BeatIfColide(opponentPiece.PosX, opponentPiece.PosY, ownPiece, opponentPlayer);
                        return;
                    }
                }
                else if (safeMoves.Count() != 0)
                {
                    
                    while (true)
                    {                       
                        Random random = new Random();
                        int posX = random.Next(8);
                        int posY = random.Next(8);

                        foreach (KeyValuePair<int[], Piece> move in safeMoves)
                        {
                            if (posX == move.Key[0] && posY == move.Key[1])
                            {
                                BeatIfColide(posX, posY, move.Value, opponentPlayer);
                                return;
                            }
                        }

                        
                    }
                }
                else if (unSafeMoves.Count() != 0)
                {

                        foreach (KeyValuePair<int[], Piece> move in safeMoves)
                        {
                            
                                BeatIfColide(move.Key[0], move.Key[1], move.Value, opponentPlayer);
                                return;
                            
                        }


                    
                }

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        foreach (Piece ownPiece in currentPlayer.Pieces)
                        {
                            if(ownPiece.IsMoveValid(x,y,currentPlayer,opponentPlayer) && IsKingSafeAfterMove(x, y, ownPiece, currentPlayer, opponentPlayer)){
                                BeatIfColide(x, y, ownPiece, opponentPlayer);
                                return;
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("{0} is checkmate, {1} is the the winner", currentPlayer.Color, opponentPlayer.Color);
                gameCode = 1;
                Console.ReadKey();
            }


            }
        private void AddMovesToLists(Dictionary<int[], Piece> safeMoves, Dictionary<int[], Piece> unSafeMoves, Dictionary<Piece, Piece> safeBeatMoves, Dictionary<Piece, Piece> unSafeBeatMoves, Player currentPlayer, Player opponentPlayer)
        { 
            // Lägger in säkra moves och osäkra moves i vars en dict 
            foreach (Piece ownPiece in currentPlayer.Pieces)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        //Safe moves
                        if (ownPiece.IsMoveValid(x, y, currentPlayer, opponentPlayer) && IsKingSafeAfterMove(x, y, ownPiece, currentPlayer, opponentPlayer) && !IsSquareThreaten(x, y, currentPlayer,opponentPlayer))
                        {
                            safeMoves.Add(new int[] { x, y }, ownPiece);
                        }

                        //Unsafe moves
                        else if (ownPiece.IsMoveValid(x, y, currentPlayer, opponentPlayer) && IsKingSafeAfterMove(x, y, ownPiece, currentPlayer, opponentPlayer))
                        {
                            unSafeMoves.Add(new int[] { x, y }, ownPiece);
                        }
                    }
                }
            }

            //Går igenom motståndarens pjäser för att se om dessa går att nå genom safe moves och unsafe moves.
           foreach(Piece opponentPiece in opponentPlayer.Pieces)
           {
                foreach (KeyValuePair<int[], Piece> SafeMove in safeMoves)
                {
                    // Om ett move matchar en av motsåndarens positioner
                    if (opponentPiece.PosX == SafeMove.Key[0] && opponentPiece.PosY == SafeMove.Key[1])
                    {
                        // Kontrollerar om egen pjäs redan har ett lagrat move
                        if (safeBeatMoves.ContainsKey(SafeMove.Value))
                        {
                            // Om pjäsen redan har ett move kontrollera om det nya movet har högre värde än de gammla.
                            if (safeBeatMoves[SafeMove.Value].Points < opponentPiece.Points)
                            {
                                safeBeatMoves[SafeMove.Value] = opponentPiece;
                            }
                        }
                        else
                        {
                            safeBeatMoves.Add(SafeMove.Value, opponentPiece);
                        }
                    }
                }
                foreach (KeyValuePair<int[], Piece> unSafeMove in unSafeMoves)
                {
                    // Om ett move matchar en av motsåndarens positioner
                    if (opponentPiece.PosX == unSafeMove.Key[0] && opponentPiece.PosY == unSafeMove.Key[1])
                    {
                        // Kontrollerar om egen pjäs redan har ett lagrat move
                        if (unSafeBeatMoves.ContainsKey(unSafeMove.Value))
                        {
                            // Om pjäsen redan har ett move kontrollera om det nya movet har högre värde än de gammla.
                            if (unSafeBeatMoves[unSafeMove.Value].Points < opponentPiece.Points)
                            {
                                unSafeBeatMoves[unSafeMove.Value] = opponentPiece;
                            }
                        }
                        else
                        {
                            unSafeBeatMoves.Add(unSafeMove.Value, opponentPiece);
                        }
                    }
                }

            }
            

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
                        if (ownPiece.IsMoveValid(x,y,currentPlayer,opponentPlayer) && !IsKingSafeAfterMove(x,y,ownPiece,opponentPlayer,currentPlayer) && IsKingSafeAfterMove(x, y, ownPiece, currentPlayer, opponentPlayer) && !IsSquareThreaten(x,y,currentPlayer,opponentPlayer))
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
        public bool IsSquareThreaten(int PosX, int PosY, Player currentPlayer, Player opponentPlayer)
        {
            /*Kontrollerar om aktuell ruta är hotad av motståndaren, främst för kungens skull
            som aldrig får flytta till hotad ruta men skulle gå att använda för att förbättra AIn 
            Loopar igenom motståndarens pjäser för att se om vald ruta är ett valid move för denna.
            Separerat pawn och king från loopen med if satser för att undvika infinite loop på king
            samt eftersom pawn inte har "validMove" till rutor om där inte redan står en opponent.*/

            foreach (Piece piece in opponentPlayer.Pieces)
            {

                if (piece.Type == "pawn")
                {
                    if (piece.PosX == PosX - 1 && piece.PosY == PosY - 1) { return true; }
                    if (piece.PosX == PosX - 1 && piece.PosY == PosY + 1) { return true; }
                    if (piece.PosX == PosX + 1 && piece.PosY == PosY + 1) { return true; }
                    if (piece.PosX == PosX + 1 && piece.PosY == PosY - 1) { return true; }
                }
                else if (piece.IsMoveValid(PosX, PosY, opponentPlayer, currentPlayer)) { return true; }

            }

            return false;
        }

    }
}
