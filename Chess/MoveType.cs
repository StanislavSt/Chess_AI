using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    public enum MoveType
    {
        Normal,
        /// <summary>Pawn which is promoted to a queen</summary>
        PawnPromotionToQueen,
        /// <summary>Castling</summary>
        Castle,
        /// <summary>Prise en passant</summary>
        PawnPromotionToRook,
        /// <summary>Pawn which is promoted to a bishop</summary>
        PawnPromotionToBishop,
        /// <summary>Pawn which is promoted to a knight</summary>
        PawnPromotionToKnight,
        /// <summary>Pawn which is promoted to a pawn</summary>
        PawnPromotionToPawn,
        /// <summary>The move eat a piece</summary>
        PieceEaten,
    }
}
