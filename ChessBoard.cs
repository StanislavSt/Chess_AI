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
            private const int tileSize = 50;
            private const int gridSize = 8;
            private Color clr1 = Color.Black;
            private Color clr2 = Color.White;
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
                            newPanel.BackColor = j % 2 != 0 ? clr1 : clr2;
                        else
                            newPanel.BackColor = j % 2 != 0 ? clr2 : clr1;
                    }
                }
            }  
    }
}
