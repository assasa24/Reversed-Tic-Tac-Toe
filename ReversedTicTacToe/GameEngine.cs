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
        private ePlayerId m_CurrentTurn;
        private int m_totalHumanPlayers;

        public GameEngine(int i_boardSize, int i_totalHumanPlayers, ePlayerSign i_player1Sign, ePlayerSign i_player2Sign)
        {
            m_Player1 = new Player(ePlayerId.Player1, i_player1Sign);
            ePlayerId player2Type;
            if (i_totalHumanPlayers == 2)
            {
                player2Type = ePlayerId.Player2;
            }
            else
            {
                Random random = new Random();
                player2Type = ePlayerId.Computer;
            }
            m_Player2 = new Player(player2Type, i_player2Sign);
            m_GameBoard = new GameBoard(i_boardSize);
            m_CurrentTurn = ePlayerId.Player1;
            m_totalHumanPlayers = i_totalHumanPlayers;
        }

        public void playTurn()
        {
            if(m_CurrentTurn == ePlayerId.Player1)
            {
                m_GameBoard.SetValueInBoard(m_Player1.ChosenMove.Item1,m_Player1.ChosenMove.Item2,m_Player1.ChosenSign);
            }
            else 
            {
                if(m_CurrentTurn == ePlayerId.Computer)
                {
                    int randX = Random.next(m_GameBoard.TotalRows+1), randY= Random.next(m_GameBoard.TotalCols+1);
                    m_Player2.ChosenMove = new Tuple<int, int>(randX, randY);
                }
                m_GameBoard.SetValueInBoard(m_Player2.ChosenMove.Item1,m_Player2.ChosenMove.Item2,m_Player2.ChosenSign);
            }
        }

        public int CheckRows()
        {
            int result = k_NotFound;
            bool isCombinationFound;

            for (int i = 0; i < m_GameBoard.TotalRows; i++)
            {
                isCombinationFound = true;
                for (int j = 0; j < m_GameBoard.TotalCols - 1; j++)
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

        public int GetTotalRows()
        {
            return m_GameBoard.TotalRows;
        }

        public int GetTotalCols()
        {
            return m_GameBoard.TotalCols;
        }

        public void setCoordinateForCurrentPlayer(int i_X, int i_Y)
        {
            if(CurrentTurn==ePlayerId.Player1)
            {
                m_Player1.ChosenMove = new Tuple<int, int>(i_X, i_Y);
            }
            else
            {
                m_Player2.ChosenMove = new Tuple<int, int>(i_X, i_Y);
            }
        }

        public ePlayerId CurrentTurn
        {
            get { return m_CurrentTurn; }
            set { m_CurrentTurn = value; }
        }

        public void nextTurn()
        {
            ePlayerId opponent;

            if (this.CurrentTurn == ePlayerId.Player1)
            {
                if (this.m_totalHumanPlayers > 1)
                {
                    opponent = ePlayerId.Player2;
                }
                else
                {
                    opponent = ePlayerId.Computer;
                }
                this.CurrentTurn = opponent;
            }
            else
            {
                this.CurrentTurn = ePlayerId.Player1;
            }
        }


        public int CheckCols()
        {
            int result = k_NotFound;
            bool isCombinationFound;

            for (int j = 0; j < m_GameBoard.TotalRows; j++)
            {
                isCombinationFound = true;
                for (int i = 0; i < m_GameBoard.TotalCols - 1; i++)
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

            for (int i = 0; i < m_GameBoard.TotalRows - 1; i++)
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
                for(int i = 0; i < m_GameBoard.TotalRows - 1; i++)
                {
                    isCombinationFound = true;
                    if(m_GameBoard.Board[i, m_GameBoard.TotalCols - 1 - i] 
                      != m_GameBoard.Board[i, m_GameBoard.TotalCols - 2 - i])
                    {
                        isCombinationFound = false;
                        break;
                    }
                }

                if (isCombinationFound)
                {
                    result = m_GameBoard.TotalCols - 1;/*second loop is the condition of right diagonal
                                                     starts with column size -1, ends with 0*/
                }
            }

            return result;
        }

        public eBoardValue getBoardValueInCoordinates(int i_X, int i_Y)
        {
            return m_GameBoard.GetValueInPosition(i_X, i_Y);
        }

        public bool isGameOver()
        {
            int losingCombinationRow, losingCombinationCol, losingCombinationDiagonal;
            bool gameOver=false;
            losingCombinationRow = CheckRows();
            losingCombinationCol = CheckCols();
            losingCombinationDiagonal = CheckDiagonals();
            eBoardValue losingSign;
            ePlayerSign player1Sign = m_Player1.ChosenSign;

            if(losingCombinationRow != k_NotFound || losingCombinationCol != k_NotFound
                ||losingCombinationDiagonal != k_NotFound)
            {
                if(losingCombinationRow != k_NotFound)
                {
                    losingSign = m_GameBoard.Board[losingCombinationRow, 0];
                }
                else if(losingCombinationCol != k_NotFound)
                {
                    losingSign = m_GameBoard.Board[0, losingCombinationCol];
                }
                else
                {
                    losingSign = m_GameBoard.Board[0, losingCombinationDiagonal];
                }
                if((char)losingSign == (char)player1Sign)
                {
                    pointsAdding("player2");
                }
                else
                {
                    pointsAdding("player1");
                }
                gameOver = true;
            }
            else if(m_GameBoard.FreeCells == 0) //tie
            {
                gameOver = true;
            }

            return gameOver;
        }

        private void pointsAdding(string i_WhoWon)
        {
            if (i_WhoWon == "player1")
            {
                m_Player1.Score++;
            }
            else
            {
                m_Player2.Score++;
            }
        }
    }
}
