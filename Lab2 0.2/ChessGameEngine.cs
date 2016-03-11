using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    class ChessGameEngine
    {
        Board _gameboard;
        Player _white;
        Player _black;
        Ui _ui;
        Ai _ai;
        Player _lastPlayer;
        Player _currentPlayer;

        public ChessGameEngine()
        {
            _gameboard = new Board();
            _white = new Player("white");
            _black = new Player("black");
            _ui = new Ui();
            _ai = new Ai();
            _lastPlayer = _black;
            Turn();

        }
        
        public void Turn()
        {
            // Kontrollerar vems tur det är genom att kontrollera vilken den senaste spelaren var.
            if (_lastPlayer == _black)
            { _currentPlayer = _white; }
            else if (_lastPlayer == _white)
            { _currentPlayer = _white; }

            // Räknar ut och gör nästa drag.
            _ai.CalculateBestMove(_currentPlayer, _lastPlayer);

            // Uppdaterar brädet med det nya draget
            _gameboard.UppdatePlayerPiecesOnBoard(_currentPlayer);

            // Skriver ut spelbrädet
            _ui.PrintBoard(_gameboard);
                
        }

    }
}
