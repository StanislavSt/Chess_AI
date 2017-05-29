using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp.AI
{
    public static class AI_Move
    {
        public static List<Location> Locations;
        public void initializeLocations(List<Location> list)
        {
            for(int i = 0 ; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    list.Add(new Location(i, j));
                }
            }
        }

        public List<ChessMove> PossibleMoves(ChessPiece[,] cb)
        {
            List<ChessMove> temp = new List<ChessMove>();
            initializeLocations(Locations);
            foreach(ChessPiece cp in cb)
            {
                if (cp != null && cp.getColor == ChessPieceColor.Black)
                {
                    switch (cp.getType)
                    {
                        case ChessPieceType.Pawn:
                            foreach(Location l in Locations)
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
                    }
                }
            }
            return temp;
        }
    }
}
