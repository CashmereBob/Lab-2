using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2_0._2;
using System.Runtime.InteropServices;

namespace WindowsForm_Chess
{
    public partial class Form1 : Form
    {
        ChessGameEngine game = null;



        string playerColor = "White is playing";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new ChessGameEngine();
            UpdateBoard();
        }
     

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AiMove_Click(object sender, EventArgs e)
        {
            game.Turn();
            UpdateBoard();
            LoggLatest();
        }

        private void UpdateBoard()
        {
            player.Text = playerColor;

            if ( playerColor == "White is playing")
            { playerColor = "Black is playing"; }
            else
            { playerColor = "White is playing"; }

            Piece[,] gameboard = game._gameboard.GameBoard;

            UpdateLable(label1A, gameboard[0, 0]);
            UpdateLable(label1B, gameboard[0, 1]);
            UpdateLable(label1C, gameboard[0, 2]);
            UpdateLable(label1D, gameboard[0, 3]);
            UpdateLable(label1E, gameboard[0, 4]);
            UpdateLable(label1F, gameboard[0, 5]);
            UpdateLable(label1G, gameboard[0, 6]);
            UpdateLable(label1H, gameboard[0, 7]);

            UpdateLable(label2A, gameboard[1, 0]);
            UpdateLable(label2B, gameboard[1, 1]);
            UpdateLable(label2C, gameboard[1, 2]);
            UpdateLable(label2D, gameboard[1, 3]);
            UpdateLable(label2E, gameboard[1, 4]);
            UpdateLable(label2F, gameboard[1, 5]);
            UpdateLable(label2G, gameboard[1, 6]);
            UpdateLable(label2H, gameboard[1, 7]);

            UpdateLable(label3A, gameboard[2, 0]);
            UpdateLable(label3B, gameboard[2, 1]);
            UpdateLable(label3C, gameboard[2, 2]);
            UpdateLable(label3D, gameboard[2, 3]);
            UpdateLable(label3E, gameboard[2, 4]);
            UpdateLable(label3F, gameboard[2, 5]);
            UpdateLable(label3G, gameboard[2, 6]);
            UpdateLable(label3H, gameboard[2, 7]);

            UpdateLable(label4A, gameboard[3, 0]);
            UpdateLable(label4B, gameboard[3, 1]);
            UpdateLable(label4C, gameboard[3, 2]);
            UpdateLable(label4D, gameboard[3, 3]);
            UpdateLable(label4E, gameboard[3, 4]);
            UpdateLable(label4F, gameboard[3, 5]);
            UpdateLable(label4G, gameboard[3, 6]);
            UpdateLable(label4H, gameboard[3, 7]);

            UpdateLable(label5A, gameboard[4, 0]);
            UpdateLable(label5B, gameboard[4, 1]);
            UpdateLable(label5C, gameboard[4, 2]);
            UpdateLable(label5D, gameboard[4, 3]);
            UpdateLable(label5E, gameboard[4, 4]);
            UpdateLable(label5F, gameboard[4, 5]);
            UpdateLable(label5G, gameboard[4, 6]);
            UpdateLable(label5H, gameboard[4, 7]);

            UpdateLable(label6A, gameboard[5, 0]);
            UpdateLable(label6B, gameboard[5, 1]);
            UpdateLable(label6C, gameboard[5, 2]);
            UpdateLable(label6D, gameboard[5, 3]);
            UpdateLable(label6E, gameboard[5, 4]);
            UpdateLable(label6F, gameboard[5, 5]);
            UpdateLable(label6G, gameboard[5, 6]);
            UpdateLable(label6H, gameboard[5, 7]);

            UpdateLable(label7A, gameboard[6, 0]);
            UpdateLable(label7B, gameboard[6, 1]);
            UpdateLable(label7C, gameboard[6, 2]);
            UpdateLable(label7D, gameboard[6, 3]);
            UpdateLable(label7E, gameboard[6, 4]);
            UpdateLable(label7F, gameboard[6, 5]);
            UpdateLable(label7G, gameboard[6, 6]);
            UpdateLable(label7H, gameboard[6, 7]);

            UpdateLable(label8A, gameboard[7, 0]);
            UpdateLable(label8B, gameboard[7, 1]);
            UpdateLable(label8C, gameboard[7, 2]);
            UpdateLable(label8D, gameboard[7, 3]);
            UpdateLable(label8E, gameboard[7, 4]);
            UpdateLable(label8F, gameboard[7, 5]);
            UpdateLable(label8G, gameboard[7, 6]);
            UpdateLable(label8H, gameboard[7, 7]);

        }

        private void UpdateLable(Label label, Piece piece)
        {
            string pieceLable = "";

            if (piece != null)
            {
                if(piece.Color == "white")
                {
                    if (piece.Type == "pawn") { pieceLable = "\u2659"; }
                    if (piece.Type == "bishop") { pieceLable = "\u2657"; }
                    if (piece.Type == "rook") { pieceLable = "\u2656"; }
                    if (piece.Type == "knight") { pieceLable = "\u2658"; }
                    if (piece.Type == "queen") { pieceLable = "\u2655"; }
                    if (piece.Type == "king") { pieceLable = "\u2654"; }

                }
                if (piece.Color == "black")
                {
                    if (piece.Type == "pawn") { pieceLable = "\u265F"; }
                    if (piece.Type == "bishop") { pieceLable = "\u265D"; }
                    if (piece.Type == "rook") { pieceLable = "\u265C"; }
                    if (piece.Type == "knight") { pieceLable = "\u265E"; }
                    if (piece.Type == "queen") { pieceLable = "\u265B"; }
                    if (piece.Type == "king") { pieceLable = "\u265A"; }
                }
            }

            label.Text = pieceLable;
        }
        private void LoggLatest()
        {
            textBoxMoves.AppendText(game._ui._latestMove + Environment.NewLine);
        }

        private void saveLogg_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            
            savefile.FileName = "Chesslogg.txt";
            
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.WriteLine(textBoxMoves.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game = new ChessGameEngine();
            playerColor = "White is playing";
            textBoxMoves.Text = "";
            UpdateBoard();
        }
    }
}
