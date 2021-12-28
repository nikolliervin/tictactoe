using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool WhoseTurn = true;
        int TurnCounter = 0;
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var Button = (Button)sender;

            switch (WhoseTurn)
            {
                case true:
                    Button.Text = "X";
                    break;
                case false:
                    Button.Text = "O";
                    break;

            }
            WhoseTurn = !WhoseTurn;
            Button.Enabled = false;

            TurnCounter++;

            WinnerCheck();
        }

        private void WinnerCheck()
        {
            bool WinnerFound = false;

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                     WinnerFound = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text)&& (!button4.Enabled))
                     WinnerFound = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text)&& (!button7.Enabled))
                     WinnerFound = true;

            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                WinnerFound = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                WinnerFound = true;
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                WinnerFound = true;

            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                WinnerFound = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
                WinnerFound = true;
           
            if (WinnerFound)
            {
                DisableAllButtons();

                string Winner = "";
                if (WhoseTurn)
                {
                    Winner = "O";
                    var O = Convert.ToInt32(OScore.Text);
                    O++;
                    OScore.Text = O.ToString();
                    
                    
                   
                }
                else
                {
                    Winner = "X";
                    var X = Convert.ToInt32(XScore.Text);

                    X++;
                    XScore.Text = X.ToString();


                }
                MessageBox.Show("The winner is: "+Winner,"We have a winner!");
            }
            else
            {
                if(TurnCounter==9)
                    MessageBox.Show("It was a draw!","Opss!");
            }


        }

        private void DisableAllButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
           

           
            }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            WhoseTurn = true;
            TurnCounter = 0;

            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
                button.Text = "";
            }
          

        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            XScore.Text = "0";
            OScore.Text = "0";
        }
    }
}
