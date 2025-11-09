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
        class RobotConnectionUserInput : RobotConnection
        {
            public RobotConnectionUserInput(string localNameOfCOMPort, int localBaudRate, string localNewLineMarkings, bool localConnectedToBot) : base(localNameOfCOMPort, localBaudRate, localNewLineMarkings, localConnectedToBot)
            {
                //this.fee = localFee;
            }

            public void createCOMPortsVariablesInheritance(int i, string tempCOMName)
            {

            }
        }

        private void ConnectToRobot_Load(object sender, EventArgs e)
        {

            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());

            string[] COMPortNames = SerialPort.GetPortNames();
            List<string> comPorts = new List<string>(COMPortNames);

            int i = 0;
            foreach (string port in comPorts)
            {
                int numberOfPorts = comPorts.Count;
                string tempCOMName = comPorts[i];
                RobotConnectionUserInput RobotConnectionUserInput = new RobotConnectionUserInput(tempCOMName, 9600, "\r\n", false);
                RobotConnectionUserInput.createCOMPortsVariablesInheritance(i, tempCOMName);

                if (numberOfPorts == 0)
                {
                    MessageBox.Show("You have no COM ports. Please connect the robot using bluetooth before opening this app");
                }
                else if (i == 0)
                {
                    RobotConnection COMPort0 = new RobotConnection(comPorts[0], 9600, "\r\n", false);
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
            if (comboBoxPorts.SelectedItem != null) // if the comboBox(the menu to select your port) is not empty
            {
                if (serialPort.IsOpen) // If the port is open, close it first
                {
                    serialPort.Close();
                }

                serialPort.PortName = comboBoxPorts.SelectedItem.ToString(); // Convert the port the user selected to a string and store it in serialPort.PortName
                serialPort.BaudRate = 9600;
                serialPort.NewLine = "\r\n";
                serialPort.DataReceived += SerialPort_DataReceived;

                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening serial port: " + ex.Message);
                }

                if (serialPort.IsOpen)
                {
                    MessageBox.Show("Serial Port Connected Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select a COM port.");
            }
        }

        

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine(); // Read line from Arduino
            this.Invoke(new MethodInvoker(delegate {
                if (data.Trim() == "clear") //.Trim avoids conflicts with other things send in the serialMonitor
                {
                    textBoxOutput.Text = "";
                }
                else
                {
                    textBoxOutput.AppendText(data + Environment.NewLine);
                }
            }));
        }
    }
}
