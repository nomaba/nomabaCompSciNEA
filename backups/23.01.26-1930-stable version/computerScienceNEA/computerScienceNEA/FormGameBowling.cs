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
        public int score = 0;
        public int lives = 2;
        public FormGameBowling()
        {
            InitializeComponent();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.sendCustomMessage("rollTheBall");
        }

        

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
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
            labelScore.Text = "Score: " + score;
        }
        public void bowlingBottlesMissed()
        {
            labelLives.Text = "Lives remaining: " + lives;
            lives = lives - 1;
            MessageBox.Show("Unlucky, You missed the pins");
            if (lives == 0)
            {
                MessageBox.Show("Game Over. Your score was " + score);

                if (score > tempclass.LoggedInAccountDetailsTemp.getBowlingHighScore())
                {
                    MessageBox.Show("NEW HIGH SCORE");
                    tempclass.LoggedInAccountDetailsTemp.updateBowlingHighScore(score);
                }
                Home Home = new Home();
                this.Close();
                Home.Show();
            }
        }
    }
}
