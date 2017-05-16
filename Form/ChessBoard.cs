using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Chess_CSharp.Engine;

namespace Chess_CSharp
{
    /// <summary>
    /// Support class for the form.
    /// Handles drawing of the board and chess pieces
    /// </summary>
    public static class ChessBoard
    {
        private const int tileSize = 60;
        private const int gridSize = 8;
        private Color color1 = Color.DarkSlateGray;
        private Color color2 = Color.White;
        private ChessPiece[,] chessBoardPieces;
        private Panel[,] chessBoardPanels;
        public ChessPiece[,] ChessBoardPieces
        {
            get { return chessBoardPieces; }
            set { chessBoardPieces = value; }
        }
        public Panel[,] ChessBoardPanels
        {
            get { return chessBoardPanels; }
            set { chessBoardPanels = value; }
        }

        public static ChessBoard()
        {
            //Initialize a 2d array of Panels, which will represent the chess board
            chessBoardPanels = new Panel[gridSize, gridSize];
            chessBoardPieces = new ChessPiece[gridSize, gridSize];
        }
        /// <summary>
        /// Draw a chess board in the given form
        /// </summary>
        /// <param name="form">The form where the board will be drawn</param>
        public void DrawBoard(Form form)
        {
            for (int i = 1; i <= gridSize; i++)
            {
                for (int j = 1; j <= gridSize; j++)
                {
                    //Create a new Panel, which represents a single board tile
                    Panel newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * i, tileSize * j),
                        Name = (i-1).ToString() + "," + (j-1).ToString()
                    };
                    //Add the Panel to the Form's controls
                    form.Controls.Add(newPanel);
                    //Add the Panel to the array of panels
                    chessBoardPanels[i - 1, j - 1] = newPanel;

                    //Color the panels
                    if (i % 2 == 0)
                        newPanel.BackColor = j % 2 != 0 ? color1 : color2;
                    else
                        newPanel.BackColor = j % 2 != 0 ? color2 : color1;
                }
            }
            DrawPositionLabels(form);
        }
        /// <summary>
        /// Draw the labels of the chess board
        /// </summary>
        /// <param name="form">Form to draw on</param>
        public void DrawPositionLabels(Form form)
        {
            char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            for (int i = 0; i < gridSize; i++)
            {
                Label intLabel = new Label
                {
                    Text = (gridSize - i).ToString(),
                    Font = new Font("Arial", 18, FontStyle.Regular),
                    Location = new Point(25, 80 + tileSize * i)
                };
                Label intLabelMirror = new Label
                {
                    Text = (gridSize - i).ToString(),
                    Font = new Font("Arial", 18, FontStyle.Regular),
                    Location = new Point(550, 80 + tileSize * i)
                };
                Label charLabel = new Label
                {
                    Text = characters[i].ToString(),
                    Font = new Font("Arial", 18, FontStyle.Regular),
                    Size = new Size(25, 25),
                    Location = new Point(77 + tileSize * i, 25)
                };
                Label charLabelMirror = new Label
                {
                    Text = characters[i].ToString(),
                    Font = new Font("Arial", 18, FontStyle.Regular),
                    Size = new Size(25, 25),
                    Location = new Point(77 + tileSize * i, 550)
                };
                form.Controls.Add(intLabel);
                form.Controls.Add(intLabelMirror);
                form.Controls.Add(charLabel);
                form.Controls.Add(charLabelMirror);
            }
        }
        /// <summary>
        /// Draws each piece on the chess board
        /// </summary>
        public void DrawPieces()
        {
            //Clear the panels
            foreach(Panel p in chessBoardPanels)
            {
                if (p.BackgroundImage != null)
                    p.BackgroundImage = null;
            }
            //Draw each piece 
            for (int i = 0; i < 8; i++)
            {
                chessBoardPanels[0, 0].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                chessBoardPanels[7, 0].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                chessBoardPanels[1, 0].BackgroundImage = Properties.Resources.Chess_Black_Knight;
                chessBoardPanels[6, 0].BackgroundImage = Properties.Resources.Chess_Black_Knight;
                chessBoardPanels[2, 0].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                chessBoardPanels[5, 0].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                chessBoardPanels[3, 0].BackgroundImage = Properties.Resources.Chess_Black_King;
                chessBoardPanels[4, 0].BackgroundImage = Properties.Resources.Chess_Black_Queen;
                chessBoardPanels[i, 1].BackgroundImage = Properties.Resources.Chess_Black_Pawn;
                chessBoardPanels[i, 6].BackgroundImage = Properties.Resources.Chess_White_Pawn;
                chessBoardPanels[0, 7].BackgroundImage = Properties.Resources.Chess_White_Rook;
                chessBoardPanels[7, 7].BackgroundImage = Properties.Resources.Chess_White_Rook;
                chessBoardPanels[1, 7].BackgroundImage = Properties.Resources.Chess_White_Knight;
                chessBoardPanels[6, 7].BackgroundImage = Properties.Resources.Chess_White_Knight;
                chessBoardPanels[2, 7].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                chessBoardPanels[5, 7].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                chessBoardPanels[3, 7].BackgroundImage = Properties.Resources.Chess_White_King;
                chessBoardPanels[4, 7].BackgroundImage = Properties.Resources.Chess_White_Queen;
            }
        }
        /// <summary>
        /// Add all buttons to the form 
        /// </summary>
        /// <param name="form">form to add the buttons</param>
        public void DrawButtons(Form form)
        {
            Button btn_newgame = new Button
            {
                Text = "New Game",
                Location = new Point(250, 620)
            };
            //Custom event handler
            btn_newgame.Click += (s, e) =>
            {
                DialogResult dr = MessageBox.Show("Do you want to start a new game ?", "New game", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DrawPieces();
                    (form as Form1).chessgame = new Chess_CSharp.Engine.Chess_Game(form);
                    (form as Form1).playerLabel.Text = "Current turn: White";
                    (form as Form1).checkLabel.Text = "King in Check : ";
                }

            };
            form.Controls.Add(btn_newgame);
            //Button btn_loadgame = new Button
            //{
            //    Text = "Load Game",
            //    Location = new Point(325, 620)
            //};
        }
        /// <summary>
        /// Return the piece on the given panel
        /// </summary>
        /// <param name="panel">Panel</param>
        /// <param name="cg">chess game</param>
        /// <returns>a ChessPiece object</returns>
        public static ChessPiece getPieceOnPanel(Panel panel, Chess_Game cg )
        {
            string[] coordinates = panel.Name.Split(',');
            return cg.getChessboard[Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1])];
        }
        /// <summary>
        /// Get the location of the selected panel
        /// </summary>
        /// <param name="panel">Panel</param>
        /// <returns>Location object</returns>
        public static Location getLocationOfPanel(Panel panel)
        {
            //We store the location of the panel in the name
            string[] coordinates = panel.Name.Split(',');
            return new Location(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
        }
    }
}
