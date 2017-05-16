using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_CSharp
{
    public static class UnderAttack
    {
        /// <summary>
        /// Get the list of white pieces under attack
        /// </summary>
        /// <param name="chessboard">2d array of chess pieces</param>
        /// <returns>List of locations under attack</returns>
        public static List<Location> getWhiteUnderAttack(ChessPiece[,] chessboard)
        {
            List<Location> underattackWhite = new List<Location>();
            foreach (ChessPiece cp in chessboard)
            {
                if (cp != null && cp.getColor == ChessPieceColor.Black)
                {
                    switch (cp.getType)
                    {
                        case ChessPieceType.Pawn:
                                underattackWhite.Add(new Location(cp.getLocation.column + 1, cp.getLocation.row + 1));
                                underattackWhite.Add(new Location(cp.getLocation.column - 1, cp.getLocation.row + 1));
                            break;
                        case ChessPieceType.Bishop:
                            checkBishop(chessboard, underattackWhite, cp);
                            break;
                        case ChessPieceType.Rook:
                            checkRook(chessboard, underattackWhite, cp);
                            break;
                        case ChessPieceType.Knight:
                            checkKnight(chessboard, underattackWhite, cp);
                            break;
                        case ChessPieceType.Queen:
                            checkBishop(chessboard, underattackWhite, cp);
                            checkRook(chessboard, underattackWhite, cp);
                            break;
                    }
                }

            }
            return underattackWhite;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chessboard"></param>
        /// <returns></returns>
        public static List<Location> getBlackUnderAttack(ChessPiece[,] chessboard)
        {
            List<Location> underattackBlack = new List<Location>();
            foreach (ChessPiece cp in chessboard)
            {
                if (cp != null && cp.getColor == ChessPieceColor.White)
                {
                    switch (cp.getType)
                    {
                        case ChessPieceType.Pawn:
                            if (cp.getLocation.column < 7 && cp.getLocation.row > 0)
                                underattackBlack.Add(new Location(cp.getLocation.column + 1, cp.getLocation.row - 1));
                            if (cp.getLocation.column > 0 && cp.getLocation.row > 0)
                                underattackBlack.Add(new Location(cp.getLocation.column - 1, cp.getLocation.row - 1));
                            break;
                        case ChessPieceType.Bishop:
                            checkBishop(chessboard, underattackBlack, cp);
                            break;
                        case ChessPieceType.Rook:
                            checkRook(chessboard, underattackBlack, cp);
                            break;
                        case ChessPieceType.Knight:
                            checkKnight(chessboard, underattackBlack, cp);
                            break;
                        case ChessPieceType.Queen:
                            checkBishop(chessboard, underattackBlack, cp);
                            checkRook(chessboard, underattackBlack, cp);
                            break;
                    }
                }

            }
            return underattackBlack;
        }

        private static void checkBishop(ChessPiece[,] chessboard, List<Location> attackList, ChessPiece cp)
        {
            //Check DownLeft
            for (int i = cp.getLocation.column - 1, j = cp.getLocation.row + 1; i >= 0 && j < 7; i--, j++)
            {
                if (chessboard[i, j] == null)
                {
                    attackList.Add(new Location(i, j));
                }
                else
                {
                    attackList.Add(new Location(i, j));
                    break;
                }
            }
            //Check DownRight
            for (int i = cp.getLocation.column + 1, j = cp.getLocation.row + 1; i < 7 && j < 7; i++, j++)
            {
                if (chessboard[i, j] == null)
                {
                    attackList.Add(new Location(i, j));
                }
                else
                {
                    attackList.Add(new Location(i, j));
                    break;
                }
            }
            //Check UpRight
            for (int i = cp.getLocation.column + 1, j = cp.getLocation.row - 1; i <= 7 && j>=0; i++, j--)
            {
                if (chessboard[i, j] == null)
                {
                    attackList.Add(new Location(i, j));
                }
                else
                {
                    attackList.Add(new Location(i, j));
                    break;
                }
            }
            //Check UpLeft
            for (int i = cp.getLocation.column - 1, j = cp.getLocation.row - 1; i >= 0 && j>=0; i--, j--)
            {
                if (chessboard[i, j] == null)
                {
                    attackList.Add(new Location(i, j));
                }
                else
                {
                    attackList.Add(new Location(i, j));
                    break;
                }
            }
        }
        private static void checkRook(ChessPiece[,] chessboard, List<Location> attackList, ChessPiece cp)
        {
            //Check Up
            for (int i = cp.getLocation.row - 1; i >= 0; i--)
            {
                if (chessboard[cp.getLocation.column, i] == null)
                    attackList.Add(new Location(cp.getLocation.column, i));
                else
                {
                    attackList.Add(new Location(cp.getLocation.column, i));
                    break;
                }
            }
            //Check Down
            for (int i = cp.getLocation.row + 1; i <= 7; i++)
            {
                if (chessboard[cp.getLocation.column, i] == null)
                    attackList.Add(new Location(cp.getLocation.column, i));
                else
                {
                    attackList.Add(new Location(cp.getLocation.column, i));
                    break;
                }
            }
            //Check Left
            for (int i = cp.getLocation.column - 1; i >= 0; i--)
            {
                if (chessboard[i, cp.getLocation.row] == null)
                    attackList.Add(new Location(i, cp.getLocation.row));
                else
                {
                    attackList.Add(new Location(i, cp.getLocation.row));
                    break;
                }
            }
                
            // Check Right
            for (int i = cp.getLocation.column + 1; i <= 7; i++)
            {
                if (chessboard[i, cp.getLocation.row] == null)
                    attackList.Add(new Location(i, cp.getLocation.row));
                else
                {
                    attackList.Add(new Location(i, cp.getLocation.row));
                    break;
                }
            }
                
        }
        private static void checkKnight(ChessPiece[,] chessboard, List<Location> attackList, ChessPiece cp)
        {
        }
    }
}
