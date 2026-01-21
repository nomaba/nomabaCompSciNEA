using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SQLite;


namespace computerScienceNEA
{
    public partial class DeveloperControls : Form
    {
        SerialPort serialPort = new SerialPort();

        public DeveloperControls()
        {
            InitializeComponent();
        }

        private void RobotControls_Load(object sender, EventArgs e)
        {

            
        }

        private void buttonSendCommand_Click(object sender, EventArgs e)
        {
            tempclass.finalisedCOMPortsTemp.sendCustomMessage(textBoxCommand.Text);
            labelPreviousCommand.Text = "Previous command sent : " + textBoxCommand.Text;
            textBoxCommand.Text = "";
        }
    }
}
