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
        public int StartPosition;
        public int EndPosition;
        public MoveType movetype;
        public ChessMove(ChessPiece piece, int startPosition, int endPosition, MoveType move)
        {
            chesspiece = piece;
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}
