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
    public partial class FormGameBowling : Form
    {
        public static int score = 0;
        public static int lives = 2;
        public static bool gameOver = false;
        public FormGameBowling()
        {
            InitializeComponent();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            
            if (gameOver == true)
            {
                MessageBox.Show("The game is over. Go to the home page.");
            }
            else
            {
                tempclass.finalisedCOMPortsTemp.sendCustomMessage("rollTheBall");
            }
        }

        

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            score = 0;
            lives = 2;
            gameOver = false;
            Home Home = new Home();
            Home.Show();
            this.Close();
        }

        private void FormGameBowling_Load(object sender, EventArgs e)
        {
            labelHighScore.Text = "High Score: " + tempclass.LoggedInAccountDetailsTemp.getBowlingHighScore();

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

        public void bowlingBottlesHit()
        {
            score = score + 1;
            MessageBox.Show("Congragulations. You hit the pins");

        }
        public void bowlingBottlesMissed()
        {
            
            lives = lives - 1;
            MessageBox.Show("Unlucky, You missed the pins");
            if (lives == 0)
            {
                MessageBox.Show("Game Over. Your score was " + score);

                if (score > tempclass.LoggedInAccountDetailsTemp.getBowlingHighScore())
                {
                    tempclass.finalisedCOMPortsTemp.sendCustomMessage("newHighScore");
                    MessageBox.Show("NEW HIGH SCORE");
                    tempclass.LoggedInAccountDetailsTemp.updateBowlingHighScore(score);
                }
                gameOver = true;
            }
        }

        private void timerUpdateLabel_Tick(object sender, EventArgs e)
        {
            labelScore.Text = "Score: " + score;
            labelLives.Text = "Lives remaining: " + lives;
        }
    }
}
