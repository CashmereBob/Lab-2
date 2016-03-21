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
        
        private System.Windows.Forms.Label[,] Cell;
        private Color firstClickUnselectedColor = Color.Aqua; 
        private int? selectedX = null, selectedY = null;

        ChessGameEngine game = null;


        public Form1()
        {
            InitializeComponent();

            // Cell's properties and event settings
            this.Cell = new Label[8, 8];

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    this.Cell[x, y] = new Label();
                    this.Cell[x, y].Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                    this.Cell[x, y].AutoSize = true;
                    this.Cell[x, y].Font = new Font("Arial Unicode MS", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    this.Cell[x, y].Location = new Point(59 + 51 * y, 56 + 51 * x);
                    this.Cell[x, y].Margin = new Padding(0);
                    this.Cell[x, y].MaximumSize = new Size(51, 51);
                    this.Cell[x, y].MinimumSize = new Size(51, 51);
                    this.Cell[x, y].Name = "Cell";
                    this.Cell[x, y].Size = new Size(51, 51);
                    this.Cell[x, y].TabIndex = 1;
                    this.Cell[x, y].TextAlign = ContentAlignment.MiddleCenter;
                    this.Cell[x, y].BackColor = ((x + y) & 1) == 0 ? Color.Gainsboro : Color.Green;
                    this.Cell[x, y].Click += new EventHandler(this.cell_Click);
                }
            }

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    this.Controls.Add(this.Cell[x, y]);
                }
            }

            player.Text = "White is playing"; //Label
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new ChessGameEngine();
            UpdateBoard();
        }
     

        /*private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void AiMove_Click(object sender, EventArgs e)
        {
            game.Turn();
            UpdateBoard();
            LoggLatest();
            player.Text = game._currentPlayer == game._black ? "Black is playing" : "White is playing";
        }

        private void UpdateBoard()
        {
            Piece[,] gameboard = game._gameboard.GameBoard;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    UpdateLable(Cell[x, y], gameboard[x, y]);
                }
            }

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
            player.Text = "White is playing";
            textBoxMoves.Text = "";
            UpdateBoard();
        }

        private void cell_Click(object sender, EventArgs e)
        {
            Color selectedColor = Color.Gray;
            labelMessage.Text = "";
            bool firstClick = selectedX == null && selectedY == null;
            //Color firstClickUnselectedColor = selectedColor; 
            //int? selectedX = null, selectedY = null; 

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (sender == Cell[x, y])
                    {
                        if (firstClick)
                        {
                            if (!game.IsCellEmpty(x, y) && game.IsCurrentPlayer(x, y))
                            {
                                firstClickUnselectedColor = this.Cell[x, y].BackColor;
                                this.Cell[x, y].BackColor = selectedColor;
                                selectedX = x;
                                selectedY = y;
                                labelMessage.Text = "";
                            }
                            else 
                            {
                                labelMessage.Text = "Empty or Not a valid piece to move.";
                            }
                        }
                        else
                        {
                            if (game.IsValidMove((int)selectedX, (int)selectedY, x, y))
                            {
                                game.Move((int)selectedX, (int)selectedY, x, y);
                                UpdateBoard();
                                LoggLatest();
                                this.Cell[(int)selectedX, (int)selectedY].BackColor = firstClickUnselectedColor;
                                selectedX = null;
                                selectedY = null;
                                player.Text = game._currentPlayer == game._black ? "Black is playing" : "White is playing";
                            }
                            else
                            {
                                labelMessage.Text = "Not a valid piece to move.";
                                this.Cell[(int)selectedX, (int)selectedY].BackColor = firstClickUnselectedColor;
                                selectedX = null;
                                selectedY = null;
                            }
                        }
                    }
                }
            }

        }

    }
}
