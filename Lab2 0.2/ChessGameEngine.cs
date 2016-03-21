using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_0._2
{
    public class ChessGameEngine
    {
        public Board _gameboard;
        public Ui _ui;
        public Player _white;
        public Player _black;
        private Ai _ai;
        private Player _opponentPlayer;
        public Player _currentPlayer;


        public ChessGameEngine()
        {
            _gameboard = new Board();
            _white = new Player("white");
            _black = new Player("black");
            _ui = new Ui();
            _ai = new Ai(_ui);
            _opponentPlayer = _white;
            _currentPlayer = _black;
            UpdateGame();

        }
        private void UpdateGame()
        {
            // Uppdaterar brädet med det nya draget
            _gameboard.UppdatePlayerPiecesOnBoard(_currentPlayer, _opponentPlayer);
            // Sätter nuvarande spelare som sist spelande runda.
            _opponentPlayer = _currentPlayer;
            if (_opponentPlayer == _black)
            {
                _currentPlayer = _white;
            }
            else if (_opponentPlayer == _white)
            {
                _currentPlayer = _black;
            }
        }

        public void Turn()
        {
            if (_ai._roundsWithoutPawnMove <= 100)
            {
                // Kontrollerar vems tur det är genom att kontrollera vilken den senaste spelaren var.

                /*
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

                } */

                _ai.CalculateBestMove(_currentPlayer, _opponentPlayer);

                UpdateGame();
            }
            else
            {
                _ui.LoggDraw();
            }
        }

        public void Move(int fromRow, int fromCol, int toRow, int toCol)
        {
            Piece piece = (Piece)_gameboard.GameBoard.GetValue(fromRow, fromCol);
            _ai.BeatIfColide(toRow, toCol, piece, _opponentPlayer);
            UpdateGame();
        }

        public bool IsCellEmpty(int row, int col)
        {
            return (Piece)_gameboard.GameBoard.GetValue(row, col) == null;
        }

        public bool IsCurrentPlayer(int row, int col)
        {
            return ((Piece)_gameboard.GameBoard.GetValue(row, col)).Color == _currentPlayer.Color; 

        }

        public bool IsValidMove(int fromRow, int fromCol, int toRow, int toCol)
        {
            Piece tmp = (Piece)_gameboard.GameBoard.GetValue(fromRow, fromCol);
            return tmp.IsMoveValid(toRow, toCol, _currentPlayer, _opponentPlayer);
        }

    }
}
