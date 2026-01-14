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
    public partial class FormAccountDetails : Form
    {
        public FormAccountDetails()
        {
            InitializeComponent();
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
        }

        private void FormAccountDetails_Load(object sender, EventArgs e)
        {
            // get user's favourite colour and then make that the background colour          
            Color newColor = Color.FromName(tempclass.LoggedInAccountDetailsTemp.getFavColour());
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

            labelNameFirst.Text = "First Name: " + tempclass.LoggedInAccountDetailsTemp.getFirstName();
            labelNameLast.Text = "Last Name: " + tempclass.LoggedInAccountDetailsTemp.getLastName();
            labelUsername.Text = "Username: " + tempclass.LoggedInAccountDetailsTemp.getUsername();
            labelDOB.Text = "Date of birth: " + tempclass.LoggedInAccountDetailsTemp.getDOBddmmyyyy();
            labelLV.Text = "LV: " + tempclass.LoggedInAccountDetailsTemp.getLV();

            labelFavColour.Text = "Favourite colour: " + tempclass.LoggedInAccountDetailsTemp.getFavColour();
            labelFavFood.Text = "Favourite Food: " + tempclass.LoggedInAccountDetailsTemp.getFavFood();
            labelFavGame.Text = "Favourite game: " + tempclass.LoggedInAccountDetailsTemp.getFavGameName();

            labelHighScoreRR.Text = "Highest score in Russian Roulette: " + tempclass.LoggedInAccountDetailsTemp.getRRHighScore();
            labelHighScoreBowling.Text = "Highest score in Bowling game: " + tempclass.LoggedInAccountDetailsTemp.getBowlingHighScore();
        }
    }
}
