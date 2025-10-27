using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace computerScienceNEA
{
    public partial class FormAccountRegister : Form
    {
        public FormAccountRegister()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
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
            string username = textBoxDatabaseUsername.Text;
            int birthDay = int.Parse(textBoxDatabaseBirthDay.Text);
            int birthMonth = int.Parse(textBoxDatabaseBirthMonth.Text);
            int birthYear = int.Parse(textBoxDatabaseBirthYear.Text);
            string favouriteColour = textBoxDatabaseFavouriteColour.Text;
            string favouriteFood = textBoxDatabaseFavouriteFood.Text;


            myCommmand.Parameters.AddWithValue("@firstName", firstName);
            myCommmand.Parameters.AddWithValue("@lastName", lastName);
            myCommmand.Parameters.AddWithValue("@password", password);
            myCommmand.Parameters.AddWithValue("@password", username);
            myCommmand.Parameters.AddWithValue("@password", birthDay);
            myCommmand.Parameters.AddWithValue("@password", birthMonth);
            myCommmand.Parameters.AddWithValue("@password", birthYear);
            myCommmand.Parameters.AddWithValue("@password", favouriteColour);
            myCommmand.Parameters.AddWithValue("@password", favouriteFood);

            myCommmand.ExecuteNonQuery();
            myConnection.Close();

            textBoxDatabaseLastName.Text = "";
            textBoxDatabaseFirstName.Text = "";
            textBoxDatabasePassword.Text = "";
        }
    }
}
