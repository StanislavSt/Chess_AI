using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp.AI
{
    public static class AI_Move
    {
        
        public static List<ChessMove> PossibleMoves(ChessPiece[,] cb, List<Location> Locations)
        {
            List<ChessMove> temp = new List<ChessMove>();
            foreach(ChessPiece cp in cb)
            {
                if (cp != null && cp.getColor == ChessPieceColor.Black)
                {
                    switch (cp.getType)
                    {
                        case ChessPieceType.Pawn:
                            foreach (var l in Locations)
                            {
                                if(LegalMove.IsPawnMove(cp,cp.getLocation,l,cb))
                                {
                                    temp.Add(new ChessMove(cp, cp.getLocation, l));
                                }
                            }
                            break;
                        case ChessPieceType.Bishop:
                            foreach (Location l in Locations)
                            {
                                if (LegalMove.IsBishopMove(cp, cp.getLocation, l, cb))
                                {
                                    temp.Add(new ChessMove(cp, cp.getLocation, l));
                                }
                            }
                            break;
                        case ChessPieceType.Queen:
                            foreach (Location l in Locations)
                            {
                                if (LegalMove.IsBishopMove(cp, cp.getLocation, l, cb) || LegalMove.IsRookMove(cp, cp.getLocation, l, cb))
                                {
                                    temp.Add(new ChessMove(cp, cp.getLocation, l));
                                }
                            }
                            break;
                        case ChessPieceType.Rook :
                            foreach (Location l in Locations)
                            {
                                if (LegalMove.IsRookMove(cp, cp.getLocation, l, cb))
                                {
                                    temp.Add(new ChessMove(cp, cp.getLocation, l));
                                }
                            }
                            break;
                        case ChessPieceType.Knight:
                            foreach (Location l in Locations)
                            {
                                if (LegalMove.IsKnightMove(cp, cp.getLocation, l, cb))
                                {
                                    temp.Add(new ChessMove(cp, cp.getLocation, l));
                                }
                            }
                            break;
                    }
                }
            }
            return temp;
        }
        //To Do : Implement Business rules
        //public ChessMove getMove()
        //{

        //}
    }
}
