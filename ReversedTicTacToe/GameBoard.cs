using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    public enum eBoardValue
    {
        X,
        O,
        Empty
    }

    class GameBoard
    {
        private int m_BoardSize;
        private eBoardValue[,] m_Board;
        public GameBoard(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_Board = new eBoardValue[m_BoardSize, m_BoardSize];
            for(int i = 0; i < m_BoardSize; i++)
            {
                for(int j = 0; j < m_BoardSize; j++)
                {
                    this.m_Board[i, j] = eBoardValue.Empty;
                }
                
            }
        }
        public void SetValueInBoard(int i_X, int i_Y, eBoardValue i_Value)
        {
            this.m_Board[i_X, i_Y] = i_Value;
            
        }
        public eBoardValue GetValueInPosition(int i_X, int i_Y)
        {
            return m_Board[i_X, i_Y];
        }
    }

    
}
