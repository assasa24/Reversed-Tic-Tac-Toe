using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    class UserInterface
    {
        private GameEngine m_GameEngine;
        
        public void GameInit()
        {
            Console.WriteLine("Hi. Welcome to a reversed tic tac toe game");
            Console.WriteLine("Please choose your board size.");
            int boardSize = boardSizeValidator();

            Console.WriteLine("Choose:");
            Console.WriteLine("1. Play vs the computer.");
            Console.WriteLine("2. Play vs a player.");
            int totalHumanPlayers = totalPlayersValidator();

            Console.WriteLine("Choose sign: X or O");
            ePlayerSign player1Sign, player2Sign;
            PlayerSignValidator(out player1Sign, out player2Sign);
            m_GameEngine = new GameEngine(boardSize, totalHumanPlayers, player1Sign, player2Sign);
        }

        private void PlayerSignValidator(out ePlayerSign player1Sign, out ePlayerSign player2Sign)
        {
            char chosenSign;

            while (!(char.TryParse(Console.ReadLine(), out chosenSign) && (chosenSign == 'x' ||
                chosenSign == 'X' || chosenSign == 'O' || chosenSign =='o')))
            {
                Console.WriteLine("invalid sign. try again");
            }

            if(chosenSign == 'X' || chosenSign == 'x')
            {
                player1Sign = ePlayerSign.X;
                player2Sign = ePlayerSign.O;
            }
            else
            {
                player1Sign = ePlayerSign.O;
                player2Sign = ePlayerSign.X;
            }
        }

        private int boardSizeValidator()
        {
            int boardSize;
            while ((!int.TryParse(Console.ReadLine(), out boardSize)) || boardSize < 3 || boardSize > 9)
            {
                Console.WriteLine("invalid size. try again");
            }

            return boardSize;
        }

        private int totalPlayersValidator() 
        {
            int totalHumanPlayers;
            while ((!int.TryParse(Console.ReadLine(), out totalHumanPlayers)) || totalHumanPlayers < 1 || totalHumanPlayers>2)
            {
                Console.WriteLine("invalid number. try again");
            }

            return totalHumanPlayers;
        }

        public void PrintBoardToScreen() 
        {
            //for(int i=0;i<;i++)
            //{
            //    for(int j=0;j<;j++)
            //    {
            //        Console.WriteLine(m_GameEngine.m_GameBoard.GetValueInPosition());
            //    }
            //}
        }

        private void printMatrixCell(eBoardValue cell)
        {
            if (cell == eBoardValue.Empty)
            {
                Console.WriteLine(" ");
            }
            else if (cell == eBoardValue.O)
            {
                Console.WriteLine("O");
            }
            else
            {
                Console.WriteLine("X");
            }
        }

        public void PlayGame()
        {
            GameInit();

            while(!m_GameEngine.isGameOver())
            {

            }

        }
    }
}
