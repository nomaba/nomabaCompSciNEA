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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            tempclass.LoggedInAccountDetailsTemp.comparedate();

            // get user's first name and display it on labelHelloTag 
            labelHelloTag.Text = "Hello " + tempclass.LoggedInAccountDetailsTemp.getUsername();

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

            // set robotState to instructions to make the robot do nothing 
            tempclass.finalisedCOMPortsTemp.setStateToValue(14); 
            int LV = tempclass.LoggedInAccountDetailsTemp.getLV();
            tempclass.finalisedCOMPortsTemp.setLVToValue(LV);


            // set the favourite game
            int? tempFavGameID;
            string tempFavGameName = "";
            tempFavGameID = tempclass.LoggedInAccountDetailsTemp.getfavGameID();

            if (tempFavGameID == null)
            {
                tempFavGameName = "No Favourite game found";
            }
            else if (tempFavGameID == 1)
            {
                tempFavGameName = "Play pet game";
            }
            else if (tempFavGameID == 2)
            {
                tempFavGameName = "Play car bot game";
            }
            else if (tempFavGameID == 3)
            {
                tempFavGameName = "Play follow game";
            }
            else if (tempFavGameID == 4)
            {
                tempFavGameName = "Play dice game";
            }
            else if (tempFavGameID == 5)
            {
                tempFavGameName = "Play russian roulette";
            }
            else if (tempFavGameID == 6)
            {
                tempFavGameName = "Play bowling game";
            }
            else
            {
                tempFavGameName = "No Favourite game found";
            }

            buttonFavGame.Text = tempFavGameName;

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // user config buttons

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            // send SQL commands to save the user data into the database and then close the application////////////////////////////////////////////////////////////////

            Application.Exit();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // open settings form and close home form
            // get the user to close and reopen the app and login again to apply settings
            FormSettings FormSettings = new FormSettings();
            this.Close();
            FormSettings.Show();
        }

        private void buttonAccountDetails_Click(object sender, EventArgs e)
        {
            // open account details form 
            FormAccountDetails FormAccountDetails = new FormAccountDetails();
            this.Close();
            FormAccountDetails.Show();
        }

        // user config buttons
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // games

        private void buttonPlayPet_Click(object sender, EventArgs e)
        {
            // open FormPet and hide Home // form pet shows the state of the robot and the LV and does nothing else // has a button to go back to home
            // set robot state to one that relies on LV
            tempclass.finalisedCOMPortsTemp.setStateToValue(0);
            FormGamePet FormGamePet = new FormGamePet();
            this.Close();
            FormGamePet.Show();
        }

        private void buttonPlayCarBot_Click(object sender, EventArgs e)
        {
            // open FormCarBot and hide Home
            // set robot state to instructions

            // the user is given 5 buttons on the PC
            // move forward
            // move backwards
            // turn left
            // turn right
            // stop motors
            // the buttons do exactly what they say on the tin

            tempclass.finalisedCOMPortsTemp.setStateToValue(14);
            FormGameCarBot FormGameCarBot = new FormGameCarBot();
            this.Close();
            FormGameCarBot.Show();
        }

        private void buttonPlayFollow_Click(object sender, EventArgs e)
        {
            // open FormFollow and hide Home
            // set robot state to follow

            // nothing special, it just follows the object infront of it
            // form follow just has a button to go back
            tempclass.finalisedCOMPortsTemp.setStateToValue(8);
            FormFollow FormFollow = new FormFollow();
            this.Close();
            FormFollow.Show();
        }

        private void buttonPlayDice_Click(object sender, EventArgs e)
        {
            // set robot state to dice

            // nothing special, its just a dice
            // the user is given the option to throw one dice or two dice
            // if the user throws one dice then one matrix display shows the number it lands on 
            // if the user throws two dice then matrix 1 shows the first dices value and the matrix 2 shows the second dice value

            tempclass.finalisedCOMPortsTemp.setStateToValue(11);

            FormGameDice FormGameDice = new FormGameDice();
            this.Close();
            FormGameDice.Show();

        }

        private void buttonPlayRussianR_Click(object sender, EventArgs e)
        {
            // set robot state to RR

            // nothing special, its just russian roulette
            //the robot moves backwards a little bit when the gun is fired

            tempclass.finalisedCOMPortsTemp.setStateToValue(12);

            FormGameRR FormGameRR = new FormGameRR();
            this.Close();
            FormGameRR.Show();
        }

        private void buttonPlayBowling_Click(object sender, EventArgs e)
        {
            // set robot state to bowling

            // bowling state moves the robot forward for 3 seconds every time the roll button is pressed on the PC
            // if an object was detected within 3 cm then the user is given a point
            // if they miss 3 shots then the game ends and the user is shown their points and then the high scores are saved in the database

            tempclass.finalisedCOMPortsTemp.setStateToValue(13);

            FormGameBowling FormGameBowling = new FormGameBowling();
            this.Close();
            FormGameBowling.Show();
        }

        private void buttonFavGame_Click(object sender, EventArgs e)
        {
            // runs a subroutine that runs the user's favourite game
            int? tempFavGameID;
            tempFavGameID = tempclass.LoggedInAccountDetailsTemp.getfavGameID();

            if (tempFavGameID == null)
            {
                MessageBox.Show("You havent selected a favourite game yet. You can set it in the settings page");
            }
            else if (tempFavGameID == 1)
            {
                buttonPlayPet_Click(sender, e);
            }
            else if (tempFavGameID == 2)
            {
                buttonPlayCarBot_Click(sender, e);
            }
            else if (tempFavGameID == 3)
            {
                buttonPlayFollow_Click(sender, e);
            }
            else if (tempFavGameID == 4)
            {
                buttonPlayDice_Click(sender, e);
            }
            else if (tempFavGameID == 5)
            {
                buttonPlayRussianR_Click(sender, e);
            }
            else if (tempFavGameID == 6)
            {
                buttonPlayBowling_Click(sender, e);
            }
            else
            {
                MessageBox.Show("You havent selected a favourite game yet. You can set it in the settings page");
            }
        }

        // games
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
