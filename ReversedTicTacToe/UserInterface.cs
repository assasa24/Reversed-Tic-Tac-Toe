using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    class UserInterface
    {
        private GameEngine m_GameEngine;
        private bool m_QuitGame;
        
        public void GameInit()
        {
            Console.WriteLine("Hi! Welcome to Reversed Tic Tac Toe");
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
            int totalRows = m_GameEngine.GetTotalRows(), totalCols = m_GameEngine.GetTotalCols();

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    printMatrixCell(m_GameEngine.getBoardValueInCoordinates(i,j));
                }
            }
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

        private void chooseMove()
        {
            int x, y;

            if (m_GameEngine.CurrentTurn != ePlayerId.Computer)
            {
                if (m_GameEngine.CurrentTurn == ePlayerId.Player1)
                {
                    Console.WriteLine("It's Player1's turn.");
                }
                else
                {
                    Console.WriteLine("It's Player2's turn.");
                }

                Console.WriteLine("Please choose your next turn in a 'row' + space key + 'column' manner");
                Console.WriteLine("For example: type '1', ' ', '2' for choosing the cell in row 1, col 2");

                coordinateValidator(out x, out y);

                m_GameEngine.setCoordinateForCurrentPlayer(x,y);
            }
        }

        private void coordinateValidator(out int x, out int y)
        {
            bool isInputValid = false;
            string coordinates;
            int totalRows = m_GameEngine.GetTotalRows();
            int totalCols = m_GameEngine.GetTotalCols();
            x = 0;
            y = 0;
            while (!isInputValid)
            {
                coordinates = Console.ReadLine();
                string[] numbers = coordinates.Split(' ');
                if(numbers[0]=="Q" || numbers[0] == "q")
                {
                    m_QuitGame = true;
                    break;
                }
                if(int.TryParse(numbers[0], out x) && int.TryParse(numbers[1], out y))
                {
                    if (!(x >= 0 && x < totalRows && y >=0 && y <= totalCols ))
                    {
                        isInputValid = true;
                    }
                }
                if(!isInputValid)
                {
                    Console.WriteLine("Invalid coordinates! Please stick to the format: 'row' + space key + 'column'");
                }
            }
        }

        public void PlayGame()
        {
            GameInit();
            PrintBoardToScreen();
            do
            {
                do
                {
                    chooseMove();
                    if(m_QuitGame)
                    {
                        break;
                    }
                    m_GameEngine.playTurn();
                    Ex02.ConsoleUtils.Screen.Clear();
                    PrintBoardToScreen();
                    m_GameEngine.nextTurn();
                }
                while (!m_GameEngine.isGameOver());
            }
            while (!stopGame());
        }
    }
}
