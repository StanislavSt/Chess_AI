using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    public class ChessPiece
    {
        private ChessPieceColor color;
        private ChessPieceType type;
        /// <summary>
        /// return the color of the chess piece
        /// </summary>
        public ChessPieceColor getColor
        {
            get { return color; }
        }
        public ChessPiece(ChessPieceColor color, ChessPieceType type)
        {
            this.color = color;
            this.type = type;
        }
    }
}
