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
        ChessBoard cb = new ChessBoard();
        //Used to store the coordinates of the mouse
        private int X;
        private int Y;
        public Form1()
        { 
            InitializeComponent();
            this.Size = new System.Drawing.Size(495, 510);
        }
        private void Panel_Hover(object sender, EventArgs e)
        {
            (sender as Panel).BorderStyle = BorderStyle.Fixed3D;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cb.DrawBoard(this);
            cb.DrawPieces();
            foreach(Panel p in cb.ChessBoardPanels)
            {
                p.MouseHover += Panel_Hover;
            }
        }

        private void m(object sender, EventArgs e)
        {

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            X = Cursor.Position.X;
            Y = Cursor.Position.Y;
            this.Text = String.Format("{0} {1}", X, Y);
        }
    }
}
