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

        public void playTurn()
        {

        }


        public bool isGameOver()
        {

        }
    }
}
