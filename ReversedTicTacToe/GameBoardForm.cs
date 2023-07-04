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
        public GameBoardForm(int i_RowsEntered, int i_ColsEntered)
        {
            this.m_Rows = i_RowsEntered;
            this.m_Cols = i_ColsEntered;
            InitializeComponent();
        }

        public void setAllButtons()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    int x = i * 80;
                    int y = j * 80;
                    Button button = new Button();
                    button.Text = "";
                    button.Location = new Point(x, y);
                    button.Size = new Size(80, 80);
                    button.Click += Button_Click;
                    Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = "X";
        }
    }
}
