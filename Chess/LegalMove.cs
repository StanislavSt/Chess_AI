using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_CSharp.Engine;

namespace Chess_CSharp
{
    public static class LegalMove
    {
        /// <summary>
        /// Check if a move is legal for a pawn
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startlocation">Location of the Chess piece</param>
        /// <param name="newlocation">New location</param>
        /// <param name="chessboard">the current chessboard</param>
        /// <returns>True if the move is legal</returns>
        public static bool IsPawnMove(ChessPiece piece, Location startlocation, Location newlocation, ChessPiece[,] chessboard)
        {
            int row  = startlocation.row;
            int column = startlocation.column;
            //White pawn
            if(piece.getColor == ChessPieceColor.White)
            {
                //Pawn special move
                if (row - newlocation.row == 2
                    && column == newlocation.column)
                {
                    //Check if Pawn is eligible for special move
                    if (row == 6
                        && chessboard[newlocation.column, newlocation.row] == null
                        && chessboard[newlocation.column, newlocation.row + 1] == null)
                        return true;
                }
                //Normal Pawn move
                else if (row - newlocation.row == 1
                    && column == newlocation.column
                    && chessboard[newlocation.column, newlocation.row] == null)
                    return true;
                //En passant
                else if (row - newlocation.row == 1
                    && chessboard[newlocation.column,newlocation.row]!= null
                    && chessboard[newlocation.column,newlocation.row].getColor != ChessPieceColor.White)
                {
                    if (column - newlocation.column == -1 || column - newlocation.column == 1)
                        return true;
                }
            }
            //Black Pawn
            else
            {
                //Pawn special move
                if (row - newlocation.row == -2
                    && column == newlocation.column)
                {
                    //Check if Pawn is eligible for special move
                    if (row == 1
                        && chessboard[newlocation.column, newlocation.row] == null
                        && chessboard[newlocation.column, newlocation.row - 1] == null)
                        return true;
                }
                //Normal Pawn move
                else if (row - newlocation.row == -1
                    && column == newlocation.column
                    && chessboard[newlocation.column, newlocation.row] == null)
                    return true;
                //En passant
                else if (row - newlocation.row == -1
                    && chessboard[newlocation.column, newlocation.row] != null
                    && chessboard[newlocation.column, newlocation.row].getColor != ChessPieceColor.Black)
                {
                    if (column - newlocation.column == -1 || column - newlocation.column == 1)
                        return true;
                }
            }
            return false;   
        }
        /// <summary>
        /// Check if a move is legal for a Rook
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startlocation">Location of the Chess piece</param>
        /// <param name="newlocation">New location</param>
        /// <param name="chessboard">the current chessboard</param>
        /// <returns>True if the move is legal</returns>
        public static bool IsRookMove(ChessPiece piece, Location startlocation, Location newlocation, ChessPiece[,] chessboard)
        {
            int row = startlocation.row;
            int column = startlocation.column;
            //Check if new location is a legal move
            if (chessboard[newlocation.column, newlocation.row] != null 
                && chessboard[newlocation.column, newlocation.row].getColor == piece.getColor)
                return false;
            //Move down
            else if (column == newlocation.column && row < newlocation.row)
            {
                for (int i = row+1; i < newlocation.row; i++)
                {
                    if (chessboard[column, i] != null)
                        return false;
                }
                    return true;
            }
            //Move up
            else if (column == newlocation.column && row > newlocation.row)
            {
                for(int i = row-1 ; i > newlocation.row; i--)
                {
                    if (chessboard[column, i] != null)
                        return false;
                }
                return true;
            }
            //Move right
            else if(row == newlocation.row && column < newlocation.column)
            {
                for(int i = column + 1; i < newlocation.column; i++)
                {
                    if (chessboard[i, row] != null)
                        return false;
                }
                return true;
            }
            //Move left
            else if (row == newlocation.row && column > newlocation.column)
            {
                for (int i = column - 1; i > newlocation.column; i--)
                {
                    if (chessboard[i, row] != null)
                        return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if a move is legal for a King
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startlocation">Location of the Chess piece</param>
        /// <param name="newlocation">New location</param>
        /// <param name="chessboard">the current chessboard</param>
        /// <returns>True if the move is legal</returns>
        public static bool IsKingMove(ChessPiece piece, Location startlocation, Location newlocation, ChessPiece[,] chessboard)
        {
            int row = startlocation.row;
            int column = startlocation.column;
            //Check if new location is a legal move
            if (chessboard[newlocation.column, newlocation.row] != null
                && chessboard[newlocation.column, newlocation.row].getColor == piece.getColor)
                return false;
            //Move up and down
            else if (column == newlocation.column)
            {
                if (row - newlocation.row == 1 || row - newlocation.row == -1)
                    return true;
            }
            //Move left and righte
            else if (row == newlocation.row)
            {
                if (column - newlocation.column == 1 || column - newlocation.column == -1)
                    return true;
            }
            //Move diagonal
            else if ((newlocation.column == startlocation.column - 1 && newlocation.row == startlocation.row + 1)
                || (newlocation.column == startlocation.column - 1 && newlocation.row == startlocation.row - 1)
                || (newlocation.column == startlocation.column + 1 && newlocation.row == startlocation.row + 1)
                || (newlocation.column == startlocation.column + 1 && newlocation.row == startlocation.row - 1))
                return true;

            return false;
        }
        /// <summary>
        /// Check if a move is legal for a Knight
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startlocation">Location of the Chess piece</param>
        /// <param name="newlocation">New location</param>
        /// <param name="chessboard">the current chessboard</param>
        /// <returns>True if the move is legal</returns>
        public static bool IsKnightMove(ChessPiece piece, Location startlocation, Location newlocation, ChessPiece[,] chessboard)
        {
            int row = startlocation.row;
            int column = startlocation.column;
            //White knight
            if (piece.getColor == ChessPieceColor.White)
            {
                //knight move
                if (
                    ((row - newlocation.row == 1
                    && (column == newlocation.column - 2 || column == newlocation.column + 2)
                    || (row - newlocation.row == -1
                    && (column == newlocation.column - 2 || column == newlocation.column + 2)))
                    || (row - newlocation.row == 2
                    && (column == newlocation.column - 1 || column == newlocation.column + 1))
                    || (row - newlocation.row == -2
                    && (column == newlocation.column - 1 || column == newlocation.column + 1)))
                    && chessboard[newlocation.column, newlocation.row] == null)
                    return true;
                //En passant
                else if ((row - newlocation.row == -1 || row - newlocation.row == 1)
                    && chessboard[newlocation.column, newlocation.row] != null
                    && chessboard[newlocation.column, newlocation.row].getColor != ChessPieceColor.White
                    )
                {
                    if (column - newlocation.column == -2 || column - newlocation.column == 2)
                        return true;
                }
                else if ((row - newlocation.row == -2 || row - newlocation.row == 2)
                    && chessboard[newlocation.column, newlocation.row] != null
                    && chessboard[newlocation.column, newlocation.row].getColor != ChessPieceColor.White)
                {
                    if (column - newlocation.column == -1 || column - newlocation.column == 1)
                        return true;
                }
            }
            //Black knight
            else
            {
                if (
                    ((row - newlocation.row == 1
                    && (column == newlocation.column - 2 || column == newlocation.column + 2)
                    || (row - newlocation.row == -1
                    && (column == newlocation.column - 2 || column == newlocation.column + 2)))
                    || (row - newlocation.row == 2
                    && (column == newlocation.column - 1 || column == newlocation.column + 1))
                    || (row - newlocation.row == -2
                    && (column == newlocation.column - 1 || column == newlocation.column + 1)))
                    && chessboard[newlocation.column, newlocation.row] == null)
                    return true;
                //En passant
                else if ((row - newlocation.row == -1 || row - newlocation.row == 1)
                    && chessboard[newlocation.column, newlocation.row] != null
                    && chessboard[newlocation.column, newlocation.row].getColor != ChessPieceColor.Black
                    )
                {
                    if (column - newlocation.column == -2 || column - newlocation.column == 2)
                        return true;
                }
                else if ((row - newlocation.row == -2 || row - newlocation.row == 2)
                    && chessboard[newlocation.column, newlocation.row] != null
                    && chessboard[newlocation.column, newlocation.row].getColor != ChessPieceColor.Black)
                {
                    if (column - newlocation.column == -1 || column - newlocation.column == 1)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if a move is legal for a Bishop
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <param name="startlocation">Location of the Chess piece</param>
        /// <param name="newlocation">New location</param>
        /// <param name="chessboard">the current chessboard</param>
        /// <returns>True if the move is legal</returns>
        public static bool IsBishopMove(ChessPiece piece, Location startlocation, Location newlocation, ChessPiece[,] chessboard)
        {
            var givenDirection = GetDirection(startlocation, newlocation);
            var fields = GetMovement(givenDirection, startlocation, newlocation);
            bool isThereSomething = fields.Any(loc => loc.column == newlocation.column && loc.row == newlocation.row);
            var thereIsSomething = fields.Select(pole => chessboard[pole.column, pole.row] != null && pole == newlocation).Any(x => x);
            if (isThereSomething && !thereIsSomething)
                return true;
            else
                return false;
        }

        private static List<Location> GetMovement(BishopDirectionType bishopDirectionType, Location startlocation, Location endLocation)
        {
            int row = startlocation.row;
            int column = startlocation.column;
            List<Location> combos = new List<Location>();
            switch (bishopDirectionType)
            {
                case BishopDirectionType.NorthEast:
                    while (row >= endLocation.row && column <= endLocation.column)
                    {
                        combos.Add(new Location(column, row));
                        row--;
                        column++;
                    }
                    break;
                case BishopDirectionType.NorthWest:
                    while (row >= endLocation.row && column >= endLocation.column)
                    {
                        combos.Add(new Location(column, row));
                        row--;
                        column--;
                    }
                    break;
                case BishopDirectionType.SouthEast:
                    while (row <= endLocation.row && column <= endLocation.column)
                    {
                        combos.Add(new Location(column, row));
                        row++;
                        column++;
                    }
                    break;
                case BishopDirectionType.SouthWest:
                    while (row <= endLocation.row && column >= endLocation.column)
                    {
                        combos.Add(new Location(column, row));
                        row++;
                        column--;
                    }
                    break;
                default:
                    break;
            }
            return combos.Where(loc => loc.column != startlocation.column && loc.row != startlocation.row).ToList();
        }

        private static BishopDirectionType GetDirection(Location startLocation, Location newLocation)
        {
            if (startLocation.row < newLocation.row && startLocation.column < newLocation.column)
            {
                return BishopDirectionType.SouthEast;
            }
            if (startLocation.row < newLocation.row && startLocation.column > newLocation.column)
            {
                return BishopDirectionType.SouthWest;
            }
            if (startLocation.row > newLocation.row && startLocation.column < newLocation.column)
            {
                return BishopDirectionType.NorthEast;
            }
            if (startLocation.row > newLocation.row && startLocation.column > newLocation.column)
            {
                return BishopDirectionType.NorthWest;
            }
            return BishopDirectionType.None;
        }
    }
}
