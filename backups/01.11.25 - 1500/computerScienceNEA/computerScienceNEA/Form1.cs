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


            FormAccountRegister FormAccountRegister = new FormAccountRegister();
            this.Hide();
            FormAccountRegister.Show();
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


        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location

            //write query
            string query = "INSERT INTO accounts(firstName, lastName, password) values (@firstName, @lastName, @password)";
            SQLiteCommand myCommmand = new SQLiteCommand(query, myConnection); // Created new variable that stores the query

            //elecute command
            myConnection.Open();

            string firstName = textBoxDatabaseFirstName.Text;
            string lastName = textBoxDatabaseLastName.Text;
            string password = textBoxDatabasePassword.Text;

            myCommmand.Parameters.AddWithValue("@firstName", firstName);
            myCommmand.Parameters.AddWithValue("@lastName", lastName);
            myCommmand.Parameters.AddWithValue("@password", password);

            myCommmand.ExecuteNonQuery();
            myConnection.Close();

            textBoxDatabaseLastName.Text = "";
            textBoxDatabaseFirstName.Text = "";
            textBoxDatabasePassword.Text = "";
        }

        private void buttonSQLSearch_Click(object sender, EventArgs e)
        {
            listBoxOutput.Items.Clear();

            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            //write query
            string query = "SELECT * FROM accounts";
            SQLiteCommand myCommmand = new SQLiteCommand(query, myConnection);

            //elecute command
            myConnection.Open();

            SQLiteDataReader result = myCommmand.ExecuteReader();
            while (result.Read())
            {
                int accountID = result.GetInt32(0);
                string firstName = result.GetString(1);
                string lastName = result.GetString(2);
                string password = result.GetString(3);

                listBoxOutput.Items.Add(accountID + " " + firstName + " " + lastName + " " + password); // ID
            }

            myConnection.Close();
        }

        private void buttonDataLogin_Click(object sender, EventArgs e)
        {
            textBoxDataLoginOutput.Text = "";

            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            //write query
            string query = "SELECT accountID, password FROM accounts WHERE accountID = @accountID AND password = @password";
            SQLiteCommand myCommmand = new SQLiteCommand(query, myConnection);

            //elecute command
            myConnection.Open();


            int accountID = int.Parse(textBoxDataLoginAccountID.Text);
            string password = textBoxDataLoginPassword.Text;

            myCommmand.Parameters.AddWithValue("@accountID", accountID);
            myCommmand.Parameters.AddWithValue("@password", password);


            SQLiteDataReader result = myCommmand.ExecuteReader();
            if (result.Read())
            {
                textBoxDataLoginOutput.Text = "login found";
            }
            else
            {
                textBoxDataLoginOutput.Text = "login not found";
            }

            myConnection.Close();
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
