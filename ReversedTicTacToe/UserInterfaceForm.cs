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
    public partial class UserInterfaceForm : Form
    {
        public UserInterfaceForm()
        {
            InitializeComponent();
        }

        private void UserInterfaceForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = "";
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(numericUpDownRows.Value != numericUpDownCols.Value
                || !(numericUpDownRows.Value >= 3 && numericUpDownRows.Value <= 8) 
                || !(numericUpDownCols.Value >= 3 && numericUpDownCols.Value <= 8))
            {
                MessageBox.Show("Invalid values for rows/cols entered. Please enter values once again.", "Invalid input");
            }
            else
            {
                int rowsEntered = (int)numericUpDownRows.Value;
                int colsEntered = (int)numericUpDownCols.Value;
                this.Hide();
                sendValuesToBoard(rowsEntered, colsEntered);
               
            }
        }

        private void sendValuesToBoard(int i_RowsEntered, int i_ColsEntered)
        {
            GameBoardForm gameBoard = new GameBoardForm(i_RowsEntered, i_ColsEntered);
            gameBoard.setAllButtons();
            gameBoard.ShowDialog();
            
        }
    }
}
