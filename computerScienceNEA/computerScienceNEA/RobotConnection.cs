using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computerScienceNEA
{
    class RobotConnection
    {
        protected string nameOfCOMPort;
        protected int baudRate;
        protected string newLineMarkings;
        protected bool connectedToBot;

        public RobotConnection(string localNameOfCOMPort, int localBaudRate, string localNewLineMarkings, bool localConnectedToBot)
        {
            this.nameOfCOMPort = localNameOfCOMPort;
            this.baudRate = localBaudRate;
            this.newLineMarkings = localNewLineMarkings;
            this.connectedToBot = localConnectedToBot;
        }

        public void connectToRobot()
        {

        }

        public void moveForward()
        {

        }



        // use inheritance to manage all of the robot com ports

        // use inheritance to check if the serial port is open before a message is sent.   
    }
}
