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
    public partial class FormGamePet : Form
    {
        public FormGamePet()
        {
            InitializeComponent();
        }

        private void FormGamePet_Load(object sender, EventArgs e)
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

            labelLV.Text = "LV:" + tempclass.LoggedInAccountDetailsTemp.getLV();

            timer1Second.Start();
        }

        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            this.Close();
            Home.Show();
        }

        private void timer1Second_Tick(object sender, EventArgs e)
        {
            labelLV.Text = "LV:" + tempclass.LoggedInAccountDetailsTemp.getLV();
        }

        private void FormGamePet_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1Second.Stop();
        }
    }
}
