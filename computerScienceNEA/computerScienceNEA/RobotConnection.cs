using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace computerScienceNEA
{
    public class RobotConnection
    {
        protected string nameOfCOMPort;
        protected int baudRate;
        protected string newLineMarkings;
        protected bool connectedToBot;

        public string tempMessageBoxMessage;

        public RobotConnection(string localNameOfCOMPort, int localBaudRate, string localNewLineMarkings, bool localConnectedToBot)
        {
            this.nameOfCOMPort = localNameOfCOMPort;
            this.baudRate = localBaudRate;
            this.newLineMarkings = localNewLineMarkings;
            this.connectedToBot = localConnectedToBot;
        }

        SerialPort serialPort = new SerialPort();

        public void connectToRobot()
        {
            if (serialPort.IsOpen) // If the port is open, close it first
            {
                serialPort.Close();
            }

            serialPort.PortName = nameOfCOMPort; // Convert the port the user selected to a string and store it in serialPort.PortName
            serialPort.BaudRate = baudRate;
            serialPort.NewLine = newLineMarkings;
            serialPort.DataReceived += SerialPort_DataReceived; // this makes the SerialPort_DataReceived subroutine run every time a message is sent by the arduino

            ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "insert message here");

            try
            {
                serialPort.Open();

                tempMessageBoxMessage = "COM Port Connected Successfully";

                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            }
            catch (Exception ex)
            {
                tempMessageBoxMessage = "Error opening serial port: " + ex.Message;
                //RobotConnection ctr = new RobotConnection("", 9600, "\r\n", false);

                
                
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
                messageBoxmessage.messageboxshow();
                //ctr.messageboxshow("");
                //messageBoxmessage.tempMessageBoxMessage = "Error: Port failed to connect!";


            }

            if (serialPort.IsOpen)
            {
                tempMessageBoxMessage = "Serial Port Connected Successfully";
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) // SerialDataReceivedEventArgs e makes the sub run when an event stated above happens // object sender is a variable that stores what activated the event
        {
            string data = serialPort.ReadLine(); // Read line from Arduino and store it in variable
            if (data.Trim() == "clear") // .trim gets rid of the extra characters the arduino sends when it sends a serial message // if the words "clear" are sent by the arduino then the screen clears
            {
                //textBoxOutput.Text = "";
            }
            else
            {
                //textBoxOutput.AppendText(data + Environment.NewLine); // adds the message from the arduino into the text box along side the already existing text in a new line
            }
        }





        public virtual void messageboxshow()
        {

        }










        public void moveForward()
        {

        }



        // use inheritance to manage all of the robot com ports

        // use inheritance to check if the serial port is open before a message is sent.   

        // since we cant send message boxes in this console, we can use inheritance to send a message box from this class into the connectToRobot class and then display it on the form there

        // change lines 59 and 63 and 45 and 50
    }
}
