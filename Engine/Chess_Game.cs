using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_CSharp.Engine
{
    public class Chess_Game
    {
        private ChessPiece[,] chessboard;
        private List<ChessMove> movelist;
        private ChessPieceColor whosturn;

        public ChessPieceColor Whosturn
        {
            get {return whosturn;}
            set {whosturn = value;}
        }
        public ChessPiece[,] getChessboard
        {
            get { return chessboard; }
        }
        public Chess_Game()
        {
            whosturn = ChessPieceColor.White;
            chessboard = new ChessPiece[8,8];
            initializeChessBoard(chessboard);
            movelist = new List<ChessMove>();

        }
        private void initializeChessBoard(ChessPiece[,] cb)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if( j == 0)
                    {
                        cb[0, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Rook);
                        cb[7, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Rook);
                        cb[1, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Knight);
                        cb[6, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Knight);
                        cb[2, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Bishop);
                        cb[5, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Bishop);
                        cb[3, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.King);
                        cb[4, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Queen);
                    }
                    else if(j == 1)
                    {
                        cb[i, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Pawn);
                    }
                    else if(j == 6)
                    {
                        cb[i, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Pawn);
                    }
                    else if(j == 7)
                    {
                        cb[0, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Rook);
                        cb[7, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Rook);
                        cb[1, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Knight);
                        cb[6, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Knight);
                        cb[2, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Bishop);
                        cb[5, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Bishop);
                        cb[3, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.King);
                        cb[4, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Queen);
                    }
                }
            }
        }
        public bool movePiece(ChessPiece piece, Panel firstPanel, Panel secondPanel)
        {
            if (piece.getColor == whosturn)
            {
                if (firstPanel.BackgroundImage != null)
                {
                    secondPanel.BackgroundImage = firstPanel.BackgroundImage;
                    firstPanel.BackgroundImage = null;
                    if (whosturn == ChessPieceColor.White)
                        whosturn = ChessPieceColor.Black;
                    else
                        whosturn = ChessPieceColor.White;
                    //Update the array 
                    //We store the coordinates in the panel's name
                    string[] fpcoordinates = firstPanel.Name.Split(',');
                    string[] spcoordinates = secondPanel.Name.Split(',');
                    chessboard[Convert.ToInt32(spcoordinates[0]), Convert.ToInt32(spcoordinates[1])] = chessboard[Convert.ToInt32(fpcoordinates[0]), Convert.ToInt32(fpcoordinates[1])];
                    chessboard[Convert.ToInt32(fpcoordinates[0]),Convert.ToInt32( fpcoordinates[1])] = null;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }
    }
}
