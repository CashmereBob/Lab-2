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
        Player _opponentPlayer;
        Player _currentPlayer;

        public ChessGameEngine()
        {
            _gameboard = new Board();
            _white = new Player("white");
            _black = new Player("black");
            _ui = new Ui();
            _ai = new Ai();
            _opponentPlayer = _white;
            _currentPlayer = _black;
            UpdateGame();

        }
        private void UpdateGame()
        {
            // Uppdaterar brädet med det nya draget
            _gameboard.UppdatePlayerPiecesOnBoard(_currentPlayer, _opponentPlayer);

            // Skriver ut spelbrädet
            _ui.PrintBoard(_gameboard);

            // Sätter nuvarande spelare som sist spelande runda.
            _opponentPlayer = _currentPlayer;
        }

        public void Turn()
        {
            // Kontrollerar vems tur det är genom att kontrollera vilken den senaste spelaren var.
            if (_opponentPlayer == _black)
            { _currentPlayer = _white; }
            else if (_opponentPlayer == _white)
            { _currentPlayer = _black; }

            // Kontrollera så att kungen safe är true annars försök flytta, om flytta ej går vinner motståndaren.
            if (_currentPlayer.IsKingSafe(_currentPlayer, _opponentPlayer))
            {
                // Räknar ut och gör nästa drag.
                _ai.CalculateBestMove(_currentPlayer, _opponentPlayer);

                UpdateGame();
                
            }
            else
            {
                // Försök flytta kungen.
                _ai.MoveKing(_currentPlayer, _opponentPlayer);

                UpdateGame();
                
            } 

            

        }

    }
}
