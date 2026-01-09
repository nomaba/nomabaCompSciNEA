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
    }
}
