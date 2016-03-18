using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_Chess
{
    
    class Ui
    {
        public string _latestMove { get; private set; }
        private int _moveCounter = 1;

        public void PrintBoard(Board board)
        {
            UpdateBoard(board);
        }

        public void LoggLatestMove(int oldPosX, int oldPosY, int newPosX, int newPosY, Piece ownPiece)
        {
            string column = "ABCDEFGH";
            _latestMove = string.Format($"     #{_moveCounter}. {ownPiece.Color} {ownPiece.Type} from {column[oldPosY]}{oldPosX+1} to {column[newPosY]}{newPosX + 1}");
            _moveCounter++;
        }

        public void LoggBeat(Piece beatenPiece)
        {
            _latestMove += string.Format($" beats {beatenPiece.Color} {beatenPiece.Type}");
        }
        public void LoggCheck()
        {
            _latestMove += string.Format($" CHECK!");
        }

        public void LoggCheckMate(Player currentPlayer)
        {
            _latestMove += string.Format($"\nCHECKMATE, GAME OVER!");
        }

        public void LoggDraw()
        {
            _latestMove = "No pawn moves or beats for 50 rounds.\nDRAW, GAME OVER!";
        }

        private void UpdateBoard(Board board)
        {
            
        }
    }
}
