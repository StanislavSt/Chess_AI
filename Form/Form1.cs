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
        public ChessBoard cb = new ChessBoard();
        Panel temp;
        public Chess_Game chessgame;
        public Label playerLabel;
        public Label checkLabel;

        public Form1()
        { 
            InitializeComponent();
            this.Size = new System.Drawing.Size(600, 715);
            chessgame = new Chess_CSharp.Engine.Chess_Game(this);
        }
        /// <summary>
        /// Custom event handler for the panels
        /// </summary>
        private void Panel_Click(object sender, EventArgs e)
        {
            //Avoid exception
            if(sender is Panel)
            {
                var panel = (Panel)sender;
                //This is the first time we click
                if(panel.BackgroundImage != null && temp == null)
                {
                    //Check wether it's this player's turn
                    if (ChessBoard.getPieceOnPanel(panel, chessgame).getColor == ChessPieceColor.White)
                    {
                        //Draw a border around the chess piece
                        temp = panel;
                        using (var panelGraphics = CreateGraphics())
                        {
                            var paintEventArgs = new PaintEventArgs(panel.CreateGraphics(),panel.ClientRectangle);
                            Panel_DrawBorder(panel, paintEventArgs);
                        }
                    }               
                }
                //This is the second click
                else if (temp != null)
                {
                    //This is the second panel , so we check if it is a legal move and perform it
                    Location startlocation = ChessBoard.getLocationOfPanel(temp);
                    Location endlocation = ChessBoard.getLocationOfPanel(panel);
                    if (chessgame.IsMoveLegal(new ChessMove(ChessBoard.getPieceOnPanel(temp, chessgame), startlocation, endlocation)))
                    {
                        chessgame.movePiece(ChessBoard.getPieceOnPanel(temp, chessgame), temp, panel);
                        temp = null;
                        List<ChessMove> list = AI.AI_Move.PossibleMoves(chessgame.getChessboard, chessgame.Locations);
                        Random r = new Random();
                        int i = r.Next(0, list.Count-1);
                        if(!chessgame.movePieceWithChessMove(list[i]))
                        {
                            string s = list[i].chesspiece.getType.ToString();
                            string end = list[i].endposition.row.ToString() + "  " + list[i].endposition.column.ToString();
                            string start = list[i].startposition.row.ToString()  + "  " + list[i].startposition.column.ToString();
                            MessageBox.Show("No move! " + s + "  "+  end + " from " + start);
                        }
                            
                    }
                    //The move is not legal so we return the panel to normal state
                    else
                    {
                        using (var panelGraphics = CreateGraphics())
                        {
                            var paintEventArgs = new PaintEventArgs(temp.CreateGraphics(), temp.ClientRectangle);
                            Panel_UndrawBorder(temp, paintEventArgs);
                        }
                        temp = null;
                    }       
                }
            }
        }
        /// <summary>
        /// Find the panel at the given Location
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Panel</returns>
        private Panel CheckPanel(Location location)
        {
            foreach(Panel p in cb.ChessBoardPanels)
            {
                //We store the location of the panel in the name
                string[] coordinates = p.Name.Split(',');
                if (location.column == Convert.ToInt32(coordinates[0]) && location.row == Convert.ToInt32(coordinates[1]))
                {
                    return p;
                }
            }
            return null;
        }
        /// <summary>
        /// Draw a green border around the panel
        /// </summary>
        /// <param name="sender">The panel object</param>
        /// <param name="p">Paint event arguments</param>
        private void Panel_DrawBorder(object sender, PaintEventArgs p)
        {
            ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.LawnGreen,ButtonBorderStyle.Solid);
        }
        /// <summary>
        /// Undraw the green border
        /// </summary>
        /// <param name="sender">Panel to be undrawn</param>
        /// <param name="p">Paint event arguments</param>
        private void Panel_UndrawBorder(Panel sender,PaintEventArgs p )
        {
            if (sender.BackColor == Color.DarkSlateGray)
                ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.DarkSlateGray, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.White, ButtonBorderStyle.Solid);
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
            playerLabel = new Label
            {
                Location = new Point(50, 620),
            };
            checkLabel = new Label
            {
                Location = new Point(50, 640),
            };
            Controls.Add(checkLabel);
            Controls.Add(playerLabel);
            
            Text = "Chess Game";
        }
    }
}
