using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_CSharp.Chess;

namespace Chess_CSharp
{
    public partial class Form1 : Form
    {
        ChessBoard cb = new ChessBoard();
        Panel temp;
        public Form1()
        { 
            InitializeComponent();
            this.Size = new System.Drawing.Size(495, 515);
        }
        /// <summary>
        /// Custom event handler for the panels
        /// </summary>
        private void Panel_Click(object sender, EventArgs e)
        {
            if(sender is Panel)
            {
                var panel = (Panel)sender;
                if (temp != null)
                {
                    ChessMove.movePiece(temp, panel);
                    temp = null;
                }
                else if(panel.BackgroundImage != null)
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
        private void Panel_DrawBorder(object sender, PaintEventArgs p)
        {
            ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.LawnGreen,ButtonBorderStyle.Solid);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Draw the panels
            cb.DrawBoard(this);
            //Draw each piece
            cb.DrawPieces();
            foreach(Panel p in cb.ChessBoardPanels)
            {
                //Subscribe each panel to the event handler
                p.MouseClick += Panel_Click;
            }
        }
    }
}
