using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_CSharp.Engine;


namespace Chess_CSharp
{
    public partial class Form1 : Form
    {
        ChessBoard cb = new ChessBoard();
        Panel temp;
        public Chess_Game chessgame;
        Label playerLabel = new Label
        {
            Location = new Point(50, 620),
        };

        public Form1()
        { 
            InitializeComponent();
            this.Size = new System.Drawing.Size(600, 715);
        }
        /// <summary>
        /// Custom event handler for the panels
        /// </summary>
        private void Panel_Click(object sender, EventArgs e)
        {
            if(sender is Panel)
            {
                var panel = (Panel)sender;
                //Check if this is the first time we click or not
                if (temp != null)
                {
                    chessgame.movePiece(ChessBoard.getPieceOnPanel(temp, chessgame), temp, panel);
                    temp = null;
                    playerLabel.Text = "Current turn: " + chessgame.Whosturn.ToString();
                }
                //Check wether it's this player's turn
                else if(panel.BackgroundImage != null)
                {
                    if (ChessBoard.getPieceOnPanel(panel, chessgame).getColor == chessgame.Whosturn)
                    {
                        temp = panel;
                        using (var panelGraphics = CreateGraphics())
                        {
                            var paintEventArgs = new PaintEventArgs(panel.CreateGraphics(),panel.ClientRectangle);
                            Panel_DrawBorder(panel, paintEventArgs);
                        }
                    }
                    
                }             
            }
        }
        private void Panel_DrawBorder(object sender, PaintEventArgs p)
        {
            //Draw a green border around the panel
            ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.LawnGreen,ButtonBorderStyle.Solid);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Draw the panels and buttons
            cb.DrawBoard(this);
            cb.DrawButtons(this);
            foreach(Panel p in cb.ChessBoardPanels)
            {
                //Subscribe each panel to the event handler
                p.MouseClick += Panel_Click;
            }
            Controls.Add(playerLabel);
            Chess_CSharp.Engine.Chess_Game chessgame = new Chess_CSharp.Engine.Chess_Game();
        }
    }
}
