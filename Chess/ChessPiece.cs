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
        private Location location;
        /// <summary>
        /// return the color of the chess piece
        /// </summary>
        public ChessPieceColor getColor
        {
            get { return color; }
        }
        public Location getLocation
        {
            get { return location; }
        }
        public ChessPieceType getType
        {
            get { return type; }
        }
        public ChessPiece(ChessPieceColor color, ChessPieceType type, Location location)
        {
            this.location = location;
            this.color = color;
            this.type = type;
        }
    }
}
