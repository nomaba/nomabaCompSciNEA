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

namespace computerScienceNEA
{
    public partial class ConnectToRobot : Form
    {
        public class RobotConnectionUserInput : RobotConnection
        {
            private string messageBoxMessage = "";
            public RobotConnectionUserInput(string localNameOfCOMPort, int localBaudRate, string localNewLineMarkings, bool localConnectedToBot, string localMessageBoxMessage) : base(localNameOfCOMPort, localBaudRate, localNewLineMarkings, localConnectedToBot) 
            {
                this.messageBoxMessage = localMessageBoxMessage;
            }

            public void updateMessageVariable(string tempMessageBoxMessage)
            {
                messageBoxMessage = tempMessageBoxMessage;
            }
            public override void messageboxshow()
            {
                MessageBox.Show(messageBoxMessage);
            }

            public void createCOMPortsVariablesInheritance(int i, string tempCOMName)
            {

            }
        }

        private void ConnectToRobot_Load(object sender, EventArgs e)
        {
            ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "messageBox");

            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());

            string[] COMPortNames = SerialPort.GetPortNames();
            List<string> comPorts = new List<string>(COMPortNames);

            int i = 0;
            foreach (string tempCOMName in comPorts)
            {
                // port is the same as comPort[i] because its storing the same thign
                int numberOfPorts = comPorts.Count;
                RobotConnectionUserInput RobotConnectionUserInput = new RobotConnectionUserInput(tempCOMName, 9600, "\r\n", false, "messageBox");
                RobotConnectionUserInput.createCOMPortsVariablesInheritance(i, tempCOMName);

                if (numberOfPorts == 0)
                {
                    MessageBox.Show("You have no COM ports. Please connect the robot using bluetooth before opening this app");
                }
                else if (i == numberOfPorts)
                {

                }
                else
                {
                    if (i == 0)
                    {
                        RobotConnection COMPort0 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 1)
                    {
                        RobotConnection COMPort1 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 2)
                    {
                        RobotConnection COMPort2 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 3)
                    {
                        RobotConnection COMPort3 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 4)
                    {
                        RobotConnection COMPort4 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 5)
                    {
                        RobotConnection COMPort5 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 6)
                    {
                        RobotConnection COMPort6 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 7)
                    {
                        RobotConnection COMPort7 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 8)
                    {
                        RobotConnection COMPort8 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                    else if (i == 9)
                    {
                        RobotConnection COMPort9 = new RobotConnection(tempCOMName, 9600, "\r\n", false);
                    }
                }
                //i++;
            }
        }

        public ConnectToRobot()
        {
            InitializeComponent();
        }

        SerialPort serialPort = new SerialPort();

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            /*progressBar.Value = 10;
            System.Threading.Thread.Sleep(2000);
            progressBar.Value = 20;
            System.Threading.Thread.Sleep(1000);
            progressBar.Value = 50;
            System.Threading.Thread.Sleep(5000); // this big delay is here to make sure everything initialises in the background properly and the progress bar is to trick the user into thinking its loading
            progressBar.Value = 60;
            System.Threading.Thread.Sleep(4000);
            progressBar.Value = 80;
            System.Threading.Thread.Sleep(3000);
            progressBar.Value = 90;*/
            if (!(comboBoxPorts.SelectedItem == null)) // if the comboBox(the menu to select your port) is not empty
            {
                if (serialPort.IsOpen) // If the port is open, close it first
                {
                    serialPort.Close();
                }

                string tempPortName = comboBoxPorts.SelectedItem.ToString(); // Convert the port the user selected to a string and store it in serialPort.PortName
                int tempBaudRate = 9600;
                string tempNewLine = "\r\n";

                progressBar.Value = 100;

                tempclass.finalisedCOMPortsTemp = new RobotConnection(tempPortName, tempBaudRate, tempNewLine, true);


                tempclass.finalisedCOMPortsTemp.connectToRobot(); // run the sub in connectToRobot class using object orentated programming

                Home Home = new Home();
                this.Hide();
                Home.Show();
            }
            else
            {
                MessageBox.Show("Please select a COM port.");
                progressBar.Value = 1;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            comboBoxPorts.Items.Clear();
            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());
        }
    }
}
