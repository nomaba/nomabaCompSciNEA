using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace DDL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location


            string queryCreateTableAccounts = @"
                CREATE TABLE accounts (
                    accountID        INTEGER PRIMARY KEY
                                             NOT NULL
                                             UNIQUE,
                    firstName        TEXT    NOT NULL,
                    lastName         TEXT    NOT NULL,
                    password         TEXT    NOT NULL,
                    username         TEXT    UNIQUE
                                             NOT NULL,
                    birthDay         INTEGER NOT NULL,
                    BirthMonth       INTEGER NOT NULL,
                    birthYear        INTEGER NOT NULL,
                    favColour        INTEGER REFERENCES colours (ColourID),
                    favFood          INTEGER REFERENCES foods (foodID),
                    LV               INTEGER NOT NULL,
                    favGameID        INTEGER REFERENCES games (gameID),
                    dateLastUsed     TEXT,
                    bowlingHighScore INTEGER,
                    RRHighScore      INTEGER
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

            string queryCreateTableGames = @" 
                CREATE TABLE games (
                    gameID   INTEGER UNIQUE
                                     PRIMARY KEY
                                     NOT NULL,
                    gameName TEXT    UNIQUE
                                     NOT NULL
                );"; // the @ at the beginning allows multiple lines to be in the string

            SQLiteCommand myCommmandCreateTableAccounts = new SQLiteCommand(queryCreateTableAccounts, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCreateTableColours = new SQLiteCommand(queryCreateTableColours, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCreateTableFoods = new SQLiteCommand(queryCreateTableFoods, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCreateTableGames = new SQLiteCommand(queryCreateTableGames, myConnection); // Created new variable that stores the query


            string queryCheckTableAccountsExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='accounts';"; //queru to access a hidden table that stores data about the database itself
            string queryCheckTableColoursExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='colours';"; //queru to access a hidden table that stores data about the database itself
            string queryCheckTableFoodsExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='foods';"; //queru to access a hidden table that stores data about the database itself
            string queryCheckTableGamesExists = "SELECT name FROM sqlite_master WHERE type='table' AND name='games';"; //queru to access a hidden table that stores data about the database itself


            SQLiteCommand myCommmandCheckTableAccountsExists = new SQLiteCommand(queryCheckTableAccountsExists, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCheckTableColoursExists = new SQLiteCommand(queryCheckTableColoursExists, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCheckTableFoodsExists = new SQLiteCommand(queryCheckTableFoodsExists, myConnection); // Created new variable that stores the query
            SQLiteCommand myCommmandCheckTableGamesExists = new SQLiteCommand(queryCheckTableGamesExists, myConnection); // Created new variable that stores the query

            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");//path.combine adds the missing bits to the path. e.g. C:// ......... /debug/database.db

            bool DatabaseExists = File.Exists(databasePath); //Does the database file exist?

            if (DatabaseExists == false)
            {
                SQLiteConnection.CreateFile(databasePath); //Create database file in this path
                // Console.WriteLine("Database file created.");

                myConnection.Open();
                myCommmandCreateTableAccounts.ExecuteNonQuery();
                // Created Accounts Table
                myCommmandCreateTableColours.ExecuteNonQuery();
                // Created Colours Table
                myCommmandCreateTableFoods.ExecuteNonQuery();
                // Created Foods Table
                myCommmandCreateTableGames.ExecuteNonQuery();
                // Created Games Table



                // Database created
            }
            else
            {
                // Database already exists
                // now checking for tables

                myConnection.Open();

                SQLiteDataReader resultCheckTableAccountsExists = myCommmandCheckTableAccountsExists.ExecuteReader();
                if (resultCheckTableAccountsExists.Read())
                {
                    // Console.WriteLine("Table accounts exists");
                    resultCheckTableAccountsExists.Close();

                }
                else
                {
                    // Console.WriteLine("Table accounts does not exists");
                    resultCheckTableAccountsExists.Close();

                    // Console.WriteLine("Creating accounts Table");

                    myCommmandCreateTableAccounts.ExecuteNonQuery();


                    // Console.WriteLine("Table accounts created successfully");
                }

                SQLiteDataReader resultCheckTableColoursExists = myCommmandCheckTableColoursExists.ExecuteReader();
                if (resultCheckTableColoursExists.Read())
                {
                    // Console.WriteLine("Table colours exists");
                    resultCheckTableColoursExists.Close();
                }
                else
                {
                    // Console.WriteLine("Table colours does not exists");
                    // Console.WriteLine("Creating colours Table");
                    resultCheckTableColoursExists.Close();
                    myCommmandCreateTableColours.ExecuteNonQuery();

                    // Console.WriteLine("Table colours created successfully");
                }

                SQLiteDataReader resultCheckTableFoodsExists = myCommmandCheckTableFoodsExists.ExecuteReader();
                if (resultCheckTableFoodsExists.Read())
                {
                    // Console.WriteLine("Table foods exists");
                    resultCheckTableFoodsExists.Close();
                }
                else
                {
                    // Console.WriteLine("Table foods does not exists");
                    // Console.WriteLine("Creating foods Table");
                    resultCheckTableFoodsExists.Close();

                    myCommmandCreateTableFoods.ExecuteNonQuery();


                    // Console.WriteLine("Table foods created successfully");
                }

                SQLiteDataReader resultCheckTableGamesExists = myCommmandCheckTableGamesExists.ExecuteReader();
                if (resultCheckTableGamesExists.Read())
                {
                    // Table games exists
                    resultCheckTableGamesExists.Close();
                }
                else
                {
                    // Table games does not exists
                    // Creating games Table
                    resultCheckTableGamesExists.Close();

                    myCommmandCreateTableGames.ExecuteNonQuery();


                    // Table games created successfully
                }


            }
            myConnection.Close();
            // Database checking complete
        }
    }
}
