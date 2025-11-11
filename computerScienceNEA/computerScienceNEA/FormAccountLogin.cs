using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace computerScienceNEA
{
    public partial class FormAccountLogin : Form
    {
        public FormAccountLogin()
        {
            InitializeComponent();
        }

        private void FormAccountLogin_Load(object sender, EventArgs e)
        {
            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location

            string queryCreateTableAccounts = @"
                CREATE TABLE accounts ( 
                    accountID  INTEGER PRIMARY KEY NOT NULL UNIQUE,
                    firstName  TEXT    NOT NULL,
                    lastName   TEXT    NOT NULL,
                    password   TEXT    NOT NULL,
                    username   TEXT    UNIQUE NOT NULL,
                    birthDay   INTEGER NOT NULL,
                    birthMonth INTEGER NOT NULL,
                    birthYear  INTEGER NOT NULL,
                    favColour  INTEGER REFERENCES colours (ColourID),
                    favFood    INTEGER REFERENCES foods (foodID),
                    LV         INTEGER NOT NULL
                );"; // the @ at the beginning allows multiple lines to be in the string

            string queryCreateTableColours = @"
                CREATE TABLE colours (
                    ColourID   INTEGER PRIMARY KEY
                                       UNIQUE
                                       NOT NULL,
                    colourName TEXT    NOT NULL
                );"; // the @ at the beginning allows multiple lines to be in the string

            string queryCreateTableFoods = @" 
                CREATE TABLE foods (
                    foodID     INTEGER PRIMARY KEY
                               NOT NULL
                               UNIQUE,
                    foodName   TEXT    NOT NULL,
                    foodColour INTEGER REFERENCES colours (ColourID) 
                );"; // the @ at the beginning allows multiple lines to be in the string

            SQLiteCommand myCommmandCreateTableAccounts = new SQLiteCommand(queryCreateTableAccounts, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCreateTableColours = new SQLiteCommand(queryCreateTableColours, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCreateTableFoods = new SQLiteCommand(queryCreateTableFoods, myConnection); // Created new variable that stores the query


            string queryCheckTableAccountsExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='accounts';"; //queru to access a hidden table that stores data about the database itself
            string queryCheckTableColoursExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='colours';"; //queru to access a hidden table that stores data about the database itself
            string queryCheckTableFoodsExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='foods';"; //queru to access a hidden table that stores data about the database itself


            SQLiteCommand myCommmandCheckTableAccountsExists = new SQLiteCommand(queryCheckTableAccountsExists, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCheckTableColoursExists = new SQLiteCommand(queryCheckTableColoursExists, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCheckTableFoodsExists = new SQLiteCommand(queryCheckTableFoodsExists, myConnection); // Created new variable that stores the query

            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");//path.combine adds the missing bits to the path. e.g. C:// ......... /debug/database.db

            bool DatabaseExists = File.Exists(databasePath); //Does the database file exist?

            if (DatabaseExists == false)
            {
                SQLiteConnection.CreateFile(databasePath); //Create database file in this path
                // Console.WriteLine("Database file created.");

                myConnection.Open();
                myCommmandCreateTableAccounts.ExecuteNonQuery();
                System.Threading.Thread.Sleep(2000);
                // Console.WriteLine("Created Accounts Table");
                myCommmandCreateTableColours.ExecuteNonQuery();
                System.Threading.Thread.Sleep(2000);
                // Console.WriteLine("Created Colours Table");
                myCommmandCreateTableFoods.ExecuteNonQuery();
                // Console.WriteLine("Created Foods Table");
                myConnection.Close();


                // Console.WriteLine("Database created successfully");
            }
            else
            {
                // Console.WriteLine("Database already exists");
                // Console.WriteLine("Checking for tables");

                myConnection.Open();

                SQLiteDataReader resultCheckTableAccountsExists = myCommmandCheckTableAccountsExists.ExecuteReader();
                if (resultCheckTableAccountsExists.Read())
                {
                    // Console.WriteLine("Table accounts exists");
                }
                else
                {
                    // Console.WriteLine("Table accounts does not exists");
                    // Console.WriteLine("Creating accounts Table");

                    myCommmandCreateTableAccounts.ExecuteNonQuery();

                    System.Threading.Thread.Sleep(2000);
                    // Console.WriteLine("Table accounts created successfully");
                }

                SQLiteDataReader resultCheckTableColoursExists = myCommmandCheckTableColoursExists.ExecuteReader();
                if (resultCheckTableColoursExists.Read())
                {
                    // Console.WriteLine("Table colours exists");
                }
                else
                {
                    // Console.WriteLine("Table colours does not exists");
                    // Console.WriteLine("Creating colours Table");

                    myCommmandCreateTableColours.ExecuteNonQuery();

                    System.Threading.Thread.Sleep(2000);
                    // Console.WriteLine("Table colours created successfully");
                }

                SQLiteDataReader resultCheckTableFoodsExists = myCommmandCheckTableFoodsExists.ExecuteReader();
                if (resultCheckTableFoodsExists.Read())
                {
                    // Console.WriteLine("Table foods exists");
                }
                else
                {
                    // Console.WriteLine("Table foods does not exists");
                    // Console.WriteLine("Creating foods Table");

                    myCommmandCreateTableFoods.ExecuteNonQuery();
                    myConnection.Close();
                    System.Threading.Thread.Sleep(2000);
                    // Console.WriteLine("Table foods created successfully");
                }

                myConnection.Close();
            }

            // Console.WriteLine("Database checking complete");
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormAccountRegister FormAccountRegister = new FormAccountRegister();
            this.Hide();
            FormAccountRegister.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            int loggedInAccountID = 0;

            if (!string.IsNullOrWhiteSpace(textBoxDatabaseLoginPassword.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseLoginUsername.Text))
            {
                //link database
                SQLiteConnection myConnection; //created new vatiable callled my connection
                myConnection = new SQLiteConnection("Data Source=database.db");

                //write query
                string query = "SELECT username, password FROM accounts WHERE username = @username AND password = @password";
                SQLiteCommand myCommmand = new SQLiteCommand(query, myConnection);

                //elecute command
                myConnection.Open();


                string username = textBoxDatabaseLoginUsername.Text;
                string password = textBoxDatabaseLoginPassword.Text;

                myCommmand.Parameters.AddWithValue("@username", username);
                myCommmand.Parameters.AddWithValue("@password", password);


                SQLiteDataReader result = myCommmand.ExecuteReader();
                if (result.Read())
                {
                    MessageBox.Show("You have logged in successfully"); // just read the text behind me


                    //write query
                    string queryWhatAccountLoggedIn = "SELECT accountID, password FROM accounts WHERE username = @username";
                    SQLiteCommand myCommmandWhatAccountLoggedIn = new SQLiteCommand(queryWhatAccountLoggedIn, myConnection);
                    myCommmandWhatAccountLoggedIn.Parameters.AddWithValue("@username", username);
                    loggedInAccountID = Convert.ToInt32(myCommmandWhatAccountLoggedIn.ExecuteScalar());

                    
                    ConnectToRobot ConnectToRobot = new ConnectToRobot();
                    this.Close();
                    ConnectToRobot.Show();
                }
                else
                {
                    MessageBox.Show("One or more of your login details are incorrect"); // just read the text behind me
                }

                myConnection.Close();
            }
            else
            {
                MessageBox.Show("One or more of your login details are incorrect");
            }


            
        }
    }
}
