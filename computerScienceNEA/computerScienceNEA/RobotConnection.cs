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

                System.Threading.Thread.Sleep(2000);






                

                serialPort.WriteLine("robotState: 14");
                System.Threading.Thread.Sleep(1000);
                serialPort.WriteLine("LV: " + "50");
            }
            catch (Exception ex)
            {
                tempMessageBoxMessage = "Error opening serial port: " + ex.Message;
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            }

            if (serialPort.IsOpen)
            {
                tempMessageBoxMessage = "Serial Port Connected Successfully";
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) // SerialDataReceivedEventArgs e makes the sub run when an event stated above happens // object sender is a variable that stores what activated the event
        {
            string data = serialPort.ReadLine(); // Read line from Arduino and store it in variable
            data = data.Trim();
            if (data == "RRLive") // .trim gets rid of the extra characters the arduino sends when it sends a serial message // if the words "clear" are sent by the arduino then the screen clears
            {
                ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "insert message here");
                tempMessageBoxMessage = "Oh No. It was live. You got shot";
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            }
            else if (data == "RRBlank")
            {
                ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "insert message here");
                tempMessageBoxMessage = "You got lucky. It was a blank";
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            } 
            else if (data == "object hit")
            {
                ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "insert message here");
                tempMessageBoxMessage = "Congragulations. You hit the pins";
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            } 
            else if (data == "object not hit")
            {
                ConnectToRobot.RobotConnectionUserInput messageBoxmessage = new ConnectToRobot.RobotConnectionUserInput("null", 9600, "\r\n", false, "insert message here");
                tempMessageBoxMessage = "Unlucky, You missed the pins";
                messageBoxmessage.updateMessageVariable(tempMessageBoxMessage);
                messageBoxmessage.messageboxshow();
            }
            else if (command.StartsWith("UPDATE LV: "))
            {
                // use string manipulation to get the LV from the command
                string lvString = command.Substring(11);
                int lv = int.Parse(lvString);

                tempclass.LoggedInAccountDetailsTemp.updateLV(lv);
            }

        }





        public virtual void messageboxshow()
        {

        }








        public void sendCustomMessage(string Message)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(Message);
            }
        }
        public void setStateToValue(int Value)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("robotState: " + Value);
            }
        }
        public void setLVToValue(int Value)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("LV: " + Value);
            }
        }
        public void moveForward()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("moveForward");
            }
        }
        public void moveBackwards()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("moveBackward");
            }   
        }
        public void turnRight()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("turnRight");
            }   
        }
        public void turnLeft()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("turnLeft");
            }   
        }
        public void stopMotors()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("stopMotors");
            }   
        }
        public void forwardUntilObstacle()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("forwardUntilObstacle");
            }   
        }
        public void spinForDuration(int time)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("spinForDuration Time: " + time);
            }   
        }
        public void forwardObstacleTurn(int time)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("forwardObstacleTurn Time: " + time);
            }   
        }
        public void motorSpeedSlow()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("motorSpeedSlow");
            }   
        }
        public void motorSpeedNormal()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("motorSpeedNormal");
            }   
        }
        public void motorSpeedFast()
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("motorSpeedFast");
            }   
        }
        public void playAudio(int audioNumber)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("playAudio: " + audioNumber);
            }   
        }
        public void changeRobotState(int stateID)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("robotState: " + stateID);
            }   
        }




        // use inheritance to manage all of the robot com ports

        // use inheritance to check if the serial port is open before a message is sent.   

        // since we cant send message boxes in this console, we can use inheritance to send a message box from this class into the connectToRobot class and then display it on the form there

        // change lines 59 and 63 and 45 and 50
    }
}
