using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversedTicTacToe
{
    public enum eBoardValue
    {
        X = 'X',
        O = 'O',
        Empty = ' '
    }

    class GameBoard
    {
        private int m_BoardSize;
        private eBoardValue[,] m_Board;
        private int m_FreeCells;


        public GameBoard(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_FreeCells = m_BoardSize * m_BoardSize;
            this.m_Board = new eBoardValue[m_BoardSize, m_BoardSize];
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    this.m_Board[i, j] = eBoardValue.Empty;
                }

            }
        }

        public int FreeCells
        {
            get { return m_FreeCells; }
            set { m_FreeCells = value; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public eBoardValue[,] Board
        {
            get
            {
                return this.m_Board;
            }
        }

        public void SetValueInBoard(int i_X, int i_Y, eBoardValue i_Value)
        {
            this.m_Board[i_X, i_Y] = i_Value;
            this.m_FreeCells--;
            
        }

        public eBoardValue GetValueInPosition(int i_X, int i_Y)
        {
            return m_Board[i_X, i_Y];
        }

        public bool CheckIfGameOVer()
        {
            bool result = false;

            for(int i = 0; i < this.m_BoardSize; i++)
            {
                for(int j = 0; j < this.m_BoardSize - 1; j++)
                {
                    if()
                }
            }
        }

       
    }

    
}
