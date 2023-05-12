using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    public enum ePlayerId
    {
        Computer,
        Player1,
        Player2

    }
    public enum ePlayerSign
    {
        X = 'X',
        O = 'O'
    }
    class Player
    {
        private ePlayerId m_PlayerId;
        private int m_Score;
        private ePlayerSign m_ChosenSign;

        public Player(ePlayerId i_PlayerId, ePlayerSign i_ChosenSign)
        {
            this.m_PlayerId = i_PlayerId;
            this.m_Score = 0;
            this.m_IsPlayersTurn = false;
            this.m_ChosenSign = i_ChosenSign;
        }
        public ePlayerId PlayerId
        {
            get { return m_PlayerId; }
            set { m_PlayerId = value; }
        }
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public ePlayerSign ChosenSign
        {
            get { return m_ChosenSign; }
            set { m_ChosenSign = value; }
        }
    }


}
