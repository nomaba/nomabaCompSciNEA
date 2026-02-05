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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        public void showMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        private void FormSettings_Load(object sender, EventArgs e)
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

            textBoxNameFirst.Text = tempclass.LoggedInAccountDetailsTemp.getFirstName();
            textBoxNameLast.Text = tempclass.LoggedInAccountDetailsTemp.getLastName();
            textBoxFavColour.Text = tempclass.LoggedInAccountDetailsTemp.getFavColour();

            string tempGameName = tempclass.LoggedInAccountDetailsTemp.getFavGameName();
            if (!(tempGameName == "null"))
            {
                comboBoxFavGame.Text = tempGameName;
            }
        }

        private void buttonFavGame_Click(object sender, EventArgs e)
        {
            if (!(comboBoxFavGame.SelectedItem == null)) // if the comboBox(the menu to select your port) is not empty
            {
                string tempGameName = comboBoxFavGame.SelectedItem.ToString();
                int tempGameID = 0;
                if (tempGameName == "pet") 
                {
                    tempGameID = 1;
                }
                else if (tempGameName == "carBot")
                {
                    tempGameID = 2;
                }
                else if (tempGameName == "follow")
                {
                    tempGameID = 3;
                }
                else if (tempGameName == "dice")
                {
                    tempGameID = 4;
                }
                else if (tempGameName == "RR")
                {
                    tempGameID = 5;
                }
                else if (tempGameName == "bowling")
                {
                    tempGameID = 6;
                }
                
                tempclass.LoggedInAccountDetailsTemp.updateFavGameID(tempGameID);
            }
            else
            {
                MessageBox.Show("You did not select a favourite game. Your Favourite game has not been updated");
            }
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
        }

        private void buttonNameFirst_Click(object sender, EventArgs e)
        {
            if (!(textBoxNameFirst.Text == null))
            {
                tempclass.LoggedInAccountDetailsTemp.updateNameFirst(textBoxNameFirst.Text);
                MessageBox.Show("First Name Updated");
            }
            else
            {
                MessageBox.Show("The textBox is empty. Your name has not been updated");
            }
        }

        private void buttonNameLast_Click(object sender, EventArgs e)
        {
            if (!(textBoxNameLast.Text == null))
            {
                tempclass.LoggedInAccountDetailsTemp.updateNameLast(textBoxNameLast.Text);
                MessageBox.Show("Last Name Updated");
            }
            else
            {
                MessageBox.Show("The textBox is empty. Your name has not been updated");
            }
        }

        private void buttonFavColour_Click(object sender, EventArgs e)
        {
            if (!(textBoxFavColour.Text == null))
            {
                Color newColor = Color.FromName(textBoxFavColour.Text);

                if (newColor.IsKnownColor)
                {
                    tempclass.LoggedInAccountDetailsTemp.updateFavColour(textBoxFavColour.Text);
                    MessageBox.Show("Favourite Colour Updated");
                } else
                {
                    MessageBox.Show("Your Favourite colour is not a valid colour. Your favourite colour has not been updated. Try making the first character a capital.");
                }
            }
            else
            {
                MessageBox.Show("The textBox is empty. Your favourite colour has not been updated");
            }
        }
    }
}
