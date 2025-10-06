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
    public partial class RobotControls : Form
    {
        SerialPort serialPort = new SerialPort();

        public RobotControls()
        {
            InitializeComponent();
        }

        private void RobotControls_Load(object sender, EventArgs e)
        {
            comboBoxPorts.Items.AddRange(SerialPort.GetPortNames());
        }



        private void lightOn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("on");
            }
        }

        private void lightOff_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("off");
            }
        }

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
            }
            else
            {
                MessageBox.Show("Please select a COM port.");
            }
        }

        private void buttonStartRobot_Click(object sender, EventArgs e)
        {

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

        private void buttonForwards_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("forward");
            }
        }

        private void buttonBackwards_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("backward");
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("right");
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("left");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("stop");
            }
        }
    }
}



/* 
Coding plan

Form1 will be a setup page for connecting to the arduino
Form2 will be where the application actually starts doing something

messages will be sent in the format "ArduinoCode - Instruction"
ArduinoCode is the unique communication code that will happen between the arduino and the computer so that other robots dont interfere with the operation
Instruction is just the instruction that the arduino is told to do - e.g. MoveForwards

HC-05
    library called SoftwareSerial can allow me to use different pins with the module and see the serial port on my laptop at the same time with serial monitor


*/
