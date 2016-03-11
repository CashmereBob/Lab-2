using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class Player
    {
        public List<Piece> Pieces { get; private set; }
        public string Color { get; private set; }

        public Player(string color)
        {
            Color = color;
            Pieces = new List<Piece>();
            InitiatePieces();
        }

        public void InitiatePieces()
        {
            //Baserat på färg bestämmer vilka rader pjäserna ska plaseras på
            int row1 = -1;
            int row2 = -1;
            if (Color == "white")
            {
                row1 = 0;
                row2 = 1;
            }
            else if (Color == "black")
            {
                row1 = 7;
                row2 = 6;
            }

            //Plaserar Bönder i y led på rad2 och lägger in i Players lista av pjäser
            for (int y = 0; y < 8; y++)
            {
                var pawn = new Pawn(row2, y, Color);
                Pieces.Add(pawn);
            }

            var king = new King(row1, 4, Color);
            Pieces.Add(king);


        }

        public void RemoveBeatenPiece(Piece beatenPiece, Piece winningPiece)
        {

            Console.WriteLine();
            Console.WriteLine("     {4} {5} from {7}-{6} ** BEATS ** {0} {1} on {3}-{2}", beatenPiece.Color, beatenPiece.Type, beatenPiece.PosX + 1, IntToChar(beatenPiece.PosY), winningPiece.Color, winningPiece.Type, winningPiece.PosX + 1, IntToChar(winningPiece.PosY));
            Pieces.Remove(beatenPiece);
            Console.ReadKey();
        }

        public bool IsKingSafe(Player currentPlayer, Player opponentPlayer)
        {

            // kontrollerar positionen på kungen.
            int KingPosX = -1;
            int KingPosY = -1;

            foreach (Piece ownPiece in Pieces)
            {
                if(ownPiece.Type == "king")
                {
                    KingPosX = ownPiece.PosX;
                    KingPosY = ownPiece.PosY;
                }
            }

            // Kontrollerar om motspelaren har pjäs som hotar kungen.

            foreach (Piece opponentPiece in opponentPlayer.Pieces)
            {
                if (opponentPiece.IsMoveValid(KingPosX, KingPosY, opponentPlayer, currentPlayer))
                {
                    return false;  
                }
            }

            return true;
        }

        private char IntToChar(int index)
        {
            
            string letters = "ABCDEFGH";

            return letters[index];
        }
    }
}
