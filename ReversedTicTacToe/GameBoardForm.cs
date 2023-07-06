using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public partial class GameBoardForm : Form
    {
        private int m_Rows;
        private int m_Cols;
        private GameEngine m_GameEngine;
        private char m_CurrentSign;
        private const int k_ButtonSize = 80;
        private bool m_IsPlayer2Human;

        public GameBoardForm(int i_RowsEntered, int i_ColsEntered, bool i_IsPlayer2Human, ePlayerSign i_Player1Sign, ePlayerSign i_Player2Sign)
        {           
            this.m_Rows = i_RowsEntered;
            this.m_Cols = i_ColsEntered;
            this.m_CurrentSign = (char)i_Player1Sign;
            m_IsPlayer2Human = i_IsPlayer2Human;

            if (m_IsPlayer2Human)
            {
                this.m_GameEngine = new GameEngine(this.m_Rows, 2, i_Player1Sign, i_Player2Sign);
            }
            else
            {
                this.m_GameEngine = new GameEngine(this.m_Rows, 1, i_Player1Sign, i_Player2Sign);
            }
            
            InitializeComponent();
        }

        public void setAllButtons()
        {
            Label labelPlayer1Score = new Label();
            Label labelPlayer2Score = new Label();
            Tuple<int, int> score = m_GameEngine.GetScore();

            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    int x = i * k_ButtonSize;
                    int y = j * k_ButtonSize;
                    BoardCell button = new BoardCell(i, j);
                    button.Text = "";
                    button.Location = new Point(x, y);
                    button.Size = new Size(k_ButtonSize, k_ButtonSize);
                    button.Click += Button_Click;
                    Controls.Add(button);
                }
            }

            labelPlayer1Score.Text = "Player1: " + score.Item1.ToString();
            labelPlayer2Score.Text = "Player2: " + score.Item2.ToString();
            labelPlayer1Score.Size = labelPlayer2Score.Size = new Size(30, 60);
            labelPlayer1Score.Location = new Point(0, this.Size.Height + 5);
            Controls.Add(labelPlayer1Score);
            this.ClientSize = new Size((m_Rows * k_ButtonSize), (m_Cols * k_ButtonSize));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string dialogTitle = "", dialogMessage = "";
            BoardCell currentCell = sender as BoardCell;

            currentCell.Text = this.m_CurrentSign.ToString();
            if (this.m_CurrentSign == 'X')
            {
                this.m_CurrentSign = 'O';
            }
            else
            {
                this.m_CurrentSign = 'X';
            }

            currentCell.Enabled = false;
            if(currentCell != null)
            {
                m_GameEngine.SetCoordinateForCurrentPlayer(currentCell.X, currentCell.Y);
            }
            m_GameEngine.PlayTurn();
            m_GameEngine.SwitchToNextPlayer();
            if (m_GameEngine.IsGameOver())
            {
                switch (m_GameEngine.RoundWinner)
                {
                    case "player1":
                        dialogTitle = "A Win";
                        dialogMessage = "The winner is player1. Would you like to play another round?";
                        break;
                    case "player2":
                        dialogTitle = "A Win";
                        if (m_IsPlayer2Human)
                        {
                            dialogMessage = "The winner is player2. Would you like to play another round?";
                        }
                        else
                        {
                            dialogMessage = "The winner is computer. Would you like to play another round?";
                        }
                        break;
                    case "tie":
                        dialogTitle = "A Tie";
                        break;
                }
                DialogResult result = MessageBox.Show(dialogMessage, dialogTitle, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // User clicked Yes
                    // Perform the desired action
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                    // User clicked No
                    // Handle accordingly or perform an alternative action
                }
            }
        }    
    }
}