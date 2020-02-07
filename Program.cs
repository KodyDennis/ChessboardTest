using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Chessboard
{
    class Program
    {
        //Create 2D array for the chessboard
        static ChessPiece[,] boardArray = new ChessPiece[8, 8];  
        
        //declare variables
        static bool gameActive = false;
        static bool gameStarted = false;
        string userInput;

        //declare chess pieces in an array -- white king, white queen, white rook, white bishop, white knight, white pawn, then repeat for black
        static string[] chessPieces = new string[] { "\u2654", "\u2655", "\u2656", "\u2657", "\u2658", "\u2659", "\u265A", "\u265B", "\u265C", "\u265D", "\u265E", "\u265F", };

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //draw blank chessboard
            if (gameActive == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < 8; j++)
                    {
                        if (((i + j) % 2) == 0)
                        {
                            //black squares
                            Console.Write("\u2395" + " ");
                        }
                        else
                        {
                            //white squares
                            Console.Write("\u23f9" + " ");
                        }
                    }
                    Console.WriteLine("|");
                }

                AskPlayerToStart();
            }


            //build chessboard with pieces and assign each piece in 2d array
            if (gameActive == true && gameStarted == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < 8; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0 || j==7)
                            {
                                Console.Write(chessPieces[2] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "rook";
                                boardArray[i, j].teamColor = "black";
                            }
                            else if(j==1 || j == 6)
                            {
                                Console.Write(chessPieces[4] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "knight";
                                boardArray[i, j].teamColor = "black";
                            }
                            else if(j==2 || j == 5)
                            {
                                Console.Write(chessPieces[3] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "bishop";
                                boardArray[i, j].teamColor = "black";
                            }
                            else if (j == 3)
                            {
                                Console.Write(chessPieces[1] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "queen";
                                boardArray[i, j].teamColor = "black";
                            }
                            else if (j == 4)
                            {
                                Console.Write(chessPieces[0] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "king";
                                boardArray[i, j].teamColor = "black";
                            }
                        }
                        else if (i == 1)
                        {
                            Console.Write(chessPieces[5] + " ");
                            boardArray[i, j] = new ChessPiece();
                            boardArray[i, j].chessClass = "pawn";
                            boardArray[i, j].teamColor = "black";
                        }
                        else if (i == 6)
                        {
                            Console.Write(chessPieces[11] + " ");
                            boardArray[i, j] = new ChessPiece();
                            boardArray[i, j].chessClass = "pawn";
                            boardArray[i, j].teamColor = "white";
                        }
                        else if (i == 7)
                        {
                            if (j == 0 || j == 7)
                            {
                                Console.Write(chessPieces[8] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "rook";
                                boardArray[i, j].teamColor = "white";
                            }
                            else if (j == 1 || j == 6)
                            {
                                Console.Write(chessPieces[10] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "knight";
                                boardArray[i, j].teamColor = "white";
                            }
                            else if (j == 2 || j == 5)
                            {
                                Console.Write(chessPieces[9] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "bishop";
                                boardArray[i, j].teamColor = "white";
                            }
                            else if (j == 3)
                            {
                                Console.Write(chessPieces[7] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "king";
                                boardArray[i, j].teamColor = "white";
                            }
                            else if (j == 4)
                            {
                                Console.Write(chessPieces[6] + " ");
                                boardArray[i, j] = new ChessPiece();
                                boardArray[i, j].chessClass = "queen";
                                boardArray[i, j].teamColor = "white";
                            }
                        }
                        else if (((i + j) % 2) == 0)
                        {
                            //black squares
                            boardArray[i, j] = new ChessPiece();
                            boardArray[i, j].chessClass = "empty";
                            boardArray[i, j].teamColor = "empty";
                            Console.Write("\u2395" + " ");
                        }
                        else
                        {
                            //white squares
                            boardArray[i, j] = new ChessPiece();
                            boardArray[i, j].chessClass = "empty";
                            boardArray[i, j].teamColor = "empty";
                            Console.Write("\u23f9" + " ");
                        }
                    }
                    Console.WriteLine("|");

                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 0 || j == 7)
                        {
                            if (((i + j) % 2) == 0)
                            {
                                boardArray[i, j].spaceColor = "black";
                            }
                            else
                            {
                                boardArray[i, j].spaceColor = "white";
                            }
                        }
                    }
                }

            }

            Console.ReadLine();
            Main();
        }


        //functions
        static void AskPlayerToStart()
        {
            //ask the player to start the game
            Console.WriteLine("Start Game? Y/N");
            string userInput = Console.ReadLine();

            if (userInput == "Y")
            {
                gameActive = true;
            }

            else if (userInput == "N")
            {
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Command not recognized. Please try again.");
                AskPlayerToStart();
            }
        }
    }

    class ChessPiece
    {
        public string chessClass;
        public string teamColor;
        public string spaceColor;
    }

}
