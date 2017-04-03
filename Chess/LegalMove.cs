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
    }
}
