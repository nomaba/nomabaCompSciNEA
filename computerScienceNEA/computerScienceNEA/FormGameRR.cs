using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerScienceNEA
{
    public partial class FormGameRR : Form
    {
        public static int score = 0;
        public static bool gameOver = false;
        public FormGameRR()
        {
            InitializeComponent();
        }

        private void buttonShoot_Click(object sender, EventArgs e)
        {
            if (gameOver == true)
            {
                MessageBox.Show("The game is over. Go back to the home page");
            } else
            {
                tempclass.finalisedCOMPortsTemp.sendCustomMessage("shootRR");
                
            }
            labelScore.Text = "Score: " + score;
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            score = 0;
            gameOver = false;
            Home Home = new Home();
            
            Home.Show();
            this.Close();
        }

        private void FormGameRR_Load(object sender, EventArgs e)
        {
            labelHighScore.Text = "High Score: " + tempclass.LoggedInAccountDetailsTemp.getRRHighScore();

            // get user's favourite colour and then make that the background colour          
            Color newColor = Color.FromName(tempclass.LoggedInAccountDetailsTemp.getFavFoodColour());
            // Check if the colour is an actual colour
            if (newColor.IsKnownColor)
            {
                this.BackColor = newColor;
            }
            else
            {
                // use the default colour (white)
                this.BackColor = Color.White;
            }
        }

        public void RRBlank()
        {
            BlankShot();
        }


        private void BlankShot() 
        {
            score = score + 1
            MessageBox.Show("You got lucky. It was a blank");
            labelScore.Text = "Score: " + score;
        }


        public void RRLive()
        {
            LiveShot();
        }

        private void LiveShot()
        {
            MessageBox.Show("Oh No. It was live. You got shot");

            MessageBox.Show("Game Over. Your score was " + score);

            if (score > tempclass.LoggedInAccountDetailsTemp.getRRHighScore())
            {
                tempclass.finalisedCOMPortsTemp.sendCustomMessage("newHighScore");
                MessageBox.Show("NEW HIGH SCORE");
                tempclass.LoggedInAccountDetailsTemp.updateRRHighScore(score);
            }
            gameOver = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
