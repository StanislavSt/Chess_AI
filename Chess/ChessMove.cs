using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_CSharp.Chess
{
    public static class ChessMove
    {
        public static bool movePiece(Panel firstPanel, Panel secondPanel)
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
        public static bool moveIsLegal()
        {
            //To be implemented
            return true;
        }
    }
}
