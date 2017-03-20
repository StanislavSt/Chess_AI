using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            this.Size = new System.Drawing.Size(620, 640);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int tileSize = 50;
            const int gridSize = 12;
            var clr1 = Color.Black;
            var clr2 = Color.White;

            
            //Initialize a 2d array of Panels, which will represent the chess board
            Panel[,] chessBoardPanels = new Panel[gridSize, gridSize];

            for(int i = 0; i < gridSize; i++)
            {
                for(int j = 0; j < gridSize; j++)
                {
                    //Create a new Panel, which represents a single board tile
                    Panel newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * i, tileSize * j)
                    };
                    //Add the Panel to the Form's controls
                    Controls.Add(newPanel);
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
