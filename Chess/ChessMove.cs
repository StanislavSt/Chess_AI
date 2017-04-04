using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    public class ChessMove
    {
        public ChessPiece chesspiece;
        public ChessPieceColor player;
        public Location startposition;
        public Location endposition;
        /// <summary>
        /// Represents a chess move
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startposition">starting position</param>
        /// <param name="endposition">end position</param>
        public ChessMove(ChessPiece piece, Location startposition, Location endposition)
        {
            this.chesspiece = piece;
            this.startposition = startposition;
            this.endposition = endposition;
            this.player = piece.getColor;
        }
    }
}
