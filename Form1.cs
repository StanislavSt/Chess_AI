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
            this.Size = new System.Drawing.Size(420, 440);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChessBoard cb = new ChessBoard();
            cb.DrawBoard(this);
        }
    }
}
