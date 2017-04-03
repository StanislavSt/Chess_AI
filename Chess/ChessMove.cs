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
        public ChessMove(ChessPiece piece, Location startposition, Location endposition)
        {
            this.chesspiece = piece;
            this.startposition = startposition;
            this.endposition = endposition;
            this.player = piece.getColor;
        }
    }
}
