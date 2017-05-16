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
        private List<Location> underattackBlack;
        private List<Location> underattackWhite;
        private Form form;
        /// <summary>
        /// Who is currently playing
        /// </summary>
        public ChessPieceColor Whosturn
        {
            get {return whosturn;}
            set {whosturn = value;}
        }
        /// <summary>
        /// return the chessboard
        /// </summary>
        public ChessPiece[,] getChessboard
        {
            get { return chessboard; }
        }
        public Chess_Game(Form form)
        {
            whosturn = ChessPieceColor.White;
            chessboard = new ChessPiece[8,8];
            initializeChessBoard(chessboard);
            movelist = new List<ChessMove>();
            underattackBlack = new List<Location>();
            underattackWhite = new List<Location>();
            this.form = form;

        }
        /// <summary>
        /// Add all ChessPieces to the chess board
        /// </summary>
        /// <param name="cb">the chessboard</param>
        private void initializeChessBoard(ChessPiece[,] cb)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if( j == 0)
                    {
                        cb[0, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Rook, new Location(0,j));
                        cb[7, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Rook, new Location(7,j));
                        cb[1, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Knight,new Location(1,j));
                        cb[6, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Knight,new Location(6,j));
                        cb[2, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Bishop,new Location(2,j));
                        cb[5, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Bishop,new Location(5,j));
                        cb[3, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.King,new Location(3,j));
                        cb[4, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Queen,new Location(4,j));
                    }
                    else if(j == 1)
                    {
                        cb[i, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Pawn,new Location(i,j));
                    }
                    else if(j == 6)
                    {
                        cb[i, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Pawn,new Location(i,j));
                    }
                    else if(j == 7)
                    {
                        cb[0, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Rook,new Location(0,j));
                        cb[7, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Rook,new Location(7,j));
                        cb[1, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Knight,new Location(1,j));
                        cb[6, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Knight,new Location(6,j));
                        cb[2, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Bishop,new Location(2,j));
                        cb[5, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Bishop,new Location(5,j));
                        cb[3, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.King,new Location(3,j));
                        cb[4, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Queen,new Location(4,j));
                    }
                }
            }
        }
        /// <summary>
        /// Move the piece
        /// </summary>
        /// <param name="piece">Chess piece</param>
        /// <returns>true if the move was successful </returns>
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
                    //We can access the coordinates from the panel's name
                    string[] fpcoordinates = firstPanel.Name.Split(',');
                    string[] spcoordinates = secondPanel.Name.Split(',');
                    chessboard[Convert.ToInt32(spcoordinates[0]), Convert.ToInt32(spcoordinates[1])] = chessboard[Convert.ToInt32(fpcoordinates[0]), Convert.ToInt32(fpcoordinates[1])];
                    chessboard[Convert.ToInt32(fpcoordinates[0]),Convert.ToInt32( fpcoordinates[1])] = null;
                    CheckUnderAttackBlack();
                    CheckUnderAttackWhite();
                    if(KingInCheck())
                    {
                        (form as Form1).checkLabel.Text = "hh";
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }
        /// <summary>
        /// Populate the list of locations under attack
        /// </summary>
        private void CheckUnderAttackWhite()
        {
            underattackWhite.Clear();
            underattackWhite = UnderAttack.getWhiteUnderAttack(chessboard).Distinct().ToList();   
        }
        /// <summary>
        /// Populate the list of locations under attack
        /// </summary>
        private void CheckUnderAttackBlack()
        {
            underattackBlack.Clear();
            underattackBlack = UnderAttack.getBlackUnderAttack(chessboard);
        }
        /// <summary>
        /// Check if a king on the board is in check
        /// </summary>
        /// <returns></returns>
        private bool KingInCheck()
        {
            foreach (Location loc in underattackBlack)
            {
                if (chessboard[loc.column, loc.row] != null)
                {
                    if (chessboard[loc.column, loc.row].getType == ChessPieceType.King && chessboard[loc.column, loc.row].getColor == ChessPieceColor.Black)
                    {
                        (form as Form1).checkLabel.Text = "King in Check : Black";
                        if (KingInMate(loc))
                        {
                            if (DialogResult.OK == MessageBox.Show("Game over, starting a new game.."))
                            {
                                (form as Form1).chessgame = new Chess_CSharp.Engine.Chess_Game(form);
                                (form as Form1).playerLabel.Text = "Current turn: White";
                                (form as Form1).cb.DrawPieces();
                            }
                        }
                        return true;
                    }
                }
                
            }
            foreach(Location loc in underattackWhite)
            {
                if (chessboard[loc.column, loc.row] != null)
                {
                    if (chessboard[loc.column, loc.row].getType == ChessPieceType.King && chessboard[loc.column, loc.row].getColor == ChessPieceColor.White)
                    {
                        (form as Form1).checkLabel.Text = "King in Check : White";
                        if(KingInMate(loc))
                        {
                            if (DialogResult.OK == MessageBox.Show("Game over, starting a new game.."))
                            {

                                (form as Form1).chessgame = new Chess_CSharp.Engine.Chess_Game(form);
                                (form as Form1).playerLabel.Text = "Current turn: White";
                                (form as Form1).cb.DrawPieces();
                            }
                        }
                        return true;
                    }
                }
            }
            (form as Form1).checkLabel.Text = "King in Check : ";
            return false;            
        }
        /// <summary>
        /// Check if King is in mate 
        /// </summary>
        /// <param name="kingloc"></param>
        /// <returns></returns>
        private bool KingInMate(Location kingloc)
        {
            return true;
        }
        /// <summary>
        /// Check if the chessmove is legal or not
        /// </summary>
        /// <param name="chessmove">Chess move</param>
        /// <returns>true if it's legal</returns>
        public bool IsMoveLegal(ChessMove chessmove)
        {
            Location startlocation = chessmove.startposition;
            Location endlocation = chessmove.endposition;
            ChessPiece chesspiece = chessmove.chesspiece;

            if(chesspiece.getType == ChessPieceType.Pawn)
            {
                if (LegalMove.IsPawnMove(chesspiece, startlocation, endlocation,this.getChessboard))
                    return true;
            }
            else if(chesspiece.getType == ChessPieceType.Rook)
            {
                if(LegalMove.IsRookMove(chesspiece,startlocation,endlocation,this.getChessboard))
                    return true;
            }
            else if (chesspiece.getType == ChessPieceType.Knight)
            {
                if (LegalMove.IsKnightMove(chesspiece, startlocation, endlocation, this.getChessboard))
                    return true;
            }
            else if (chesspiece.getType == ChessPieceType.Bishop)
            {
                if (LegalMove.IsBishopMove(chesspiece, startlocation, endlocation, this.getChessboard))
                    return true;
            }
            else if (chesspiece.getType == ChessPieceType.King)
            {
                if (LegalMove.IsKingMove(chesspiece, startlocation, endlocation, this.getChessboard))
                    return true;
            }
            else if(chesspiece.getType == ChessPieceType.Queen)
            {
                //Combine Rook and Bishop
                if (LegalMove.IsRookMove(chesspiece, startlocation, endlocation, this.getChessboard) || LegalMove.IsBishopMove(chesspiece, startlocation, endlocation, this.getChessboard))
                    return true;
            }
            return false;
        }
    }
}
