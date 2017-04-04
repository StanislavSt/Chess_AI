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
        /// <summary>
        /// Default constructor for a ChessPiece
        /// </summary>
        /// <param name="color">black/white</param>
        /// <param name="type">Type of chess piece</param>
        /// <param name="location">location on the board</param>
        public ChessPiece(ChessPieceColor color, ChessPieceType type, Location location)
        {
            this.location = location;
            this.color = color;
            this.type = type;
        }
    }
}
