using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    class GameEngine
    {
        private Player m_Player1;
        private Player m_Player2;
        private GameBoard m_GameBoard;
        private const int k_NotFound = -1;

        public GameEngine(int i_boardSize, int i_totalHumanPlayers, ePlayerSign player1Sign, ePlayerSign player2Sign)
        {
            m_Player1 = new Player(ePlayerId.Player1, player1Sign);
            ePlayerId player2Type;
            if (i_totalHumanPlayers == 2)
            {
                player2Type = ePlayerId.Player2;
            }
            else
            {
                player2Type = ePlayerId.Computer;
            }
            m_Player2 = new Player(player2Type, player2Sign);
            m_GameBoard = new GameBoard(i_boardSize);
        }

        public void playTurn(Player currentPlayer)
        {

        }

        public int CheckRows()
        {
            int result = k_NotFound;
            bool isCombinationFound;

            for (int i = 0; i < m_GameBoard.BoardSize; i++)
            {
                isCombinationFound = true;
                for (int j = 0; j < m_GameBoard.BoardSize - 1; j++)
                {
                    if (m_GameBoard.Board[i, j] != m_GameBoard.Board[i, j + 1])
                    {
                        isCombinationFound = false;
                        break;
                    }
                }

                if (isCombinationFound)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public int CheckCols()
        {
            int result = k_NotFound;
            bool isCombinationFound;

            for (int j = 0; j < m_GameBoard.BoardSize; j++)
            {
                isCombinationFound = true;
                for (int i = 0; i < m_GameBoard.BoardSize - 1; i++)
                {
                    if (m_GameBoard.Board[i, j] != m_GameBoard.Board[i + 1, j])
                    {
                        isCombinationFound = false;
                        break;
                    }

                }

                if (isCombinationFound)
                {
                    result = j;
                    break;
                }
            }

            return result;
        }

        public int CheckDiagonals()
        {
            int result = k_NotFound;
            bool isCombinationFound = true;

            for (int i = 0; i < m_GameBoard.BoardSize - 1; i++)
            {
                isCombinationFound = true;
                if(m_GameBoard.Board[i, i] != m_GameBoard.Board[i+1, i+1])
                {
                    isCombinationFound = false;
                    break;
                }
            }

            if(isCombinationFound)
            {
                result = 0;/*first loop is the condition of left diagonal.
                             starts with 0. ends with bottom right*/
            }
            else
            {
                for(int i = 0; i < m_GameBoard.BoardSize - 1; i++)
                {
                    isCombinationFound = true;
                    if(m_GameBoard.Board[i, m_GameBoard.BoardSize - 1 - i] 
                      != m_GameBoard.Board[i, m_GameBoard.BoardSize - 2 - i])
                    {
                        isCombinationFound = false;
                        break;
                    }
                }

                if (isCombinationFound)
                {
                    result = m_GameBoard.BoardSize - 1;/*second loop is the condition of right diagonal
                                                     starts with column size -1, ends with 0*/
                }
            }

            return result;
        }

        public string isGameOver()
        {
            int losingCombinationRow, losingCombinationCol, losingCombinationDiagonal;
            string whoLost;
            losingCombinationRow = CheckRows();
            losingCombinationCol = CheckCols();
            losingCombinationDiagonal = CheckDiagonals();
            eBoardValue losingSign;
            ePlayerSign player1Sign = m_Player1.ChosenSign;
            ePlayerSign player2Sign = m_Player2.ChosenSign;

            if(losingCombinationRow != k_NotFound)
            {
                losingSign = m_GameBoard.Board[losingCombinationRow, 0];
                if((char)losingSign == (char)player1Sign)
                {
                    whoLost = "player1";
                }
                else
                {
                    whoLost = "player2/cpu";
                }
                

            }
            else if(losingCombinationCol != k_NotFound)
            {
                losingSign = m_GameBoard.Board[0, losingCombinationCol];
                if(losingSign == m_Player1.ChosenSign)
            }
            else if(losingCombinationDiagonal != k_NotFound)
            {
                losingSign = m_GameBoard.Board[0, losingCombinationDiagonal];
            }
            else if(m_GameBoard.FreeCells == 0)
            {
                whoLost = "nobody";
            }



            return result;
        }
    }
}
