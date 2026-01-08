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
    public partial class FormGameCarBot : Form
    {
        public FormGameCarBot()
        {
            InitializeComponent();
        }

        private void buttonForwards_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.moveForward();
        }

        private void buttonBackwards_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.moveBackwards();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.turnLeft();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.turnRight();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.stopMotors();
        }

        private void FormGameCarBot_Load(object sender, EventArgs e)
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
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
        }
    }
}
