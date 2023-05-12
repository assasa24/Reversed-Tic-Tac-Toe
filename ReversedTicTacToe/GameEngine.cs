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


        public bool isGameOver()
        {
            bool result = false;
            bool isCombinationFound;

            for(int i = 0; i < m_GameBoard.BoardSize; i++)
            {
                isCombinationFound = true;
                for(int j = 0; j < m_GameBoard.BoardSize - 1; j++)
                {
                    if(m_GameBoard.Board[i, j] != m_GameBoard.Board[i, j + 1])
                    {
                        isCombinationFound = false;
                        break;
                    }

                }
                
                if(isCombinationFound)
                {
                    result = true;
                    break;
                }
            }
            if(!result)
            {
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
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
