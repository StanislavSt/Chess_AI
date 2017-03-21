using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_CSharp
{
    class ChessBoard
    {
            private const int tileSize = 60;
            private const int gridSize = 8;
            private Color colorGrey= Color.DarkSlateGray;
            private Color colorWhite= Color.White;
            private Panel[,] chessBoardPanels;
            public Panel[,] ChessBoardPanels
            {
                get { return chessBoardPanels; }
                set { chessBoardPanels = value; }
            }   
            public ChessBoard()
            {
                //Initialize a 2d array of Panels, which will represent the chess board
                ChessBoardPanels = new Panel[gridSize, gridSize];
            }
            /// <summary>
            /// Draw a board in the given form
            /// </summary>
            /// <param name="form">The form where the board will be drawn</param>
            public void DrawBoard(Form form)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        //Create a new Panel, which represents a single board tile
                        Panel newPanel = new Panel
                        {
                            Size = new Size(tileSize, tileSize),
                            Location = new Point(tileSize * i, tileSize * j)
                        };
                        //Add the Panel to the Form's controls
                        form.Controls.Add(newPanel);
                        //Add the Panel to the array of panels
                        chessBoardPanels[i, j] = newPanel;

                        //Color the panels
                        if (i % 2 == 0)
                            newPanel.BackColor = j % 2 != 0 ? colorGrey : colorWhite;
                        else
                            newPanel.BackColor = j % 2 != 0 ? colorWhite : colorGrey;
                    }
                }
            }
        /// <summary>
        /// Draws each piece on the chess board
        /// </summary>
        public void DrawPieces()
        {
            for(int i = 0 ; i < gridSize ; i ++ )
            {
                for(int j = 0 ; j < gridSize ; j++)
                {
                    switch(j)
                    {
                        case 0 :
                            chessBoardPanels[0, j].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                            chessBoardPanels[7, j].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                            chessBoardPanels[1, j].BackgroundImage = Properties.Resources.Chess_Black_Knight;
                            chessBoardPanels[6, j].BackgroundImage = Properties.Resources.Chess_Black_Knight;
                            chessBoardPanels[2, j].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                            chessBoardPanels[5, j].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                            chessBoardPanels[3, j].BackgroundImage = Properties.Resources.Chess_Black_King;
                            chessBoardPanels[4, j].BackgroundImage = Properties.Resources.Chess_Black_Queen;
                            break;
                        case 1 : 
                            chessBoardPanels[i, j].BackgroundImage = Properties.Resources.Chess_Black_Pawn;
                            break;
                        case 6 :
                            chessBoardPanels[i, j].BackgroundImage = Properties.Resources.Chess_White_Pawn;
                            break;
                        case 7 : 
                            chessBoardPanels[0, j].BackgroundImage = Properties.Resources.Chess_White_Rook;
                            chessBoardPanels[7, j].BackgroundImage = Properties.Resources.Chess_White_Rook;
                            chessBoardPanels[1, j].BackgroundImage = Properties.Resources.Chess_White_Knight;
                            chessBoardPanels[6, j].BackgroundImage = Properties.Resources.Chess_White_Knight;
                            chessBoardPanels[2, j].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                            chessBoardPanels[5, j].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                            chessBoardPanels[3, j].BackgroundImage = Properties.Resources.Chess_White_King;
                            chessBoardPanels[4, j].BackgroundImage = Properties.Resources.Chess_White_Queen;
                            break;
                    }   
                }
            }
        }

        public bool movePiece(Panel firstPanel, Panel secondPanel)
        {
            if (firstPanel.BackgroundImage != null)
            {
                secondPanel.BackgroundImage = firstPanel.BackgroundImage;
                firstPanel.BackgroundImage = null;
                return true;
            }
            else
                return false;
        }
    }
}
