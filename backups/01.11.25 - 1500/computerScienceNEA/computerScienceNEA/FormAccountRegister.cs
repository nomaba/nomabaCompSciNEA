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
            bool validUserInput = false;

            if (validUserInput == false)
            {

            }
            else
            {

            }
            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location











            //write query
            string queryAccounts = "INSERT INTO accounts(firstName, lastName, password, username, birthDay, birthMonth, birthYear, favColour, favFood) values (@firstName, @lastName, @password, @username, @birthDay, @birthMonth, @birthYear, @favColour, @favFood)";
            SQLiteCommand myCommmandAccounts = new SQLiteCommand(queryAccounts, myConnection); // Created new variable that stores the query

            


            //works dont touch
            string queryCheckColourExists = "SELECT colourName FROM colours WHERE colourName = @favColour";
            SQLiteCommand myCommmandCheckColourExists = new SQLiteCommand(queryCheckColourExists, myConnection); // Created new variable that stores the query
            myCommmandCheckColourExists.Parameters.AddWithValue("@favColour", textBoxDatabaseFavouriteColour.Text);
            myConnection.Open();
            SQLiteDataReader resultCheckColourExists = myCommmandCheckColourExists.ExecuteReader();
            if (resultCheckColourExists.Read())
            {
                //do nothing
            }
            else
            {
                string queryColours = "INSERT INTO colours(colourName) values (@favColour)";
                SQLiteCommand myCommmandColours = new SQLiteCommand(queryColours, myConnection); // Created new variable that stores the query
                myCommmandColours.Parameters.AddWithValue("@favColour", textBoxDatabaseFavouriteColour.Text);
                myCommmandColours.ExecuteNonQuery();          
            }
            myConnection.Close();
            //above works dont touch

            //works dont touch
            string queryCheckFoodExists = "SELECT foodID FROM foods WHERE foodName = @favFood";
            SQLiteCommand myCommmandCheckFoodExists = new SQLiteCommand(queryCheckFoodExists, myConnection); // Created new variable that stores the query
            myCommmandCheckFoodExists.Parameters.AddWithValue("@favFood", textBoxDatabaseFavouriteColour.Text);
            myConnection.Open();
            SQLiteDataReader resultCheckFoodExists = myCommmandCheckFoodExists.ExecuteReader();
            if (resultCheckFoodExists.Read())
            {
                //do nothing
            }
            else
            {
                string queryAddNewFood = "INSERT INTO foods(foodName, foodColour) values (@foodName, @foodColour)";
                SQLiteCommand myCommmandFood = new SQLiteCommand(queryAddNewFood, myConnection); // Created new variable that stores the query
                myCommmandFood.Parameters.AddWithValue("@foodName", textBoxDatabaseFavouriteFood.Text);
                myCommmandFood.Parameters.AddWithValue("@foodColour", textBoxFavouriteFoodColour.Text);
                myCommmandFood.ExecuteNonQuery();
            }
            myConnection.Close();
            //above works dont touch









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
            string favouriteFoodColour = textBoxDatabaseFavouriteFood.Text;


            myCommmandAccounts.Parameters.AddWithValue("@firstName", firstName);
            myCommmandAccounts.Parameters.AddWithValue("@lastName", lastName);
            myCommmandAccounts.Parameters.AddWithValue("@password", password);
            myCommmandAccounts.Parameters.AddWithValue("@username", username);
            myCommmandAccounts.Parameters.AddWithValue("@birthDay", birthDay);
            myCommmandAccounts.Parameters.AddWithValue("@birthMonth", birthMonth);
            myCommmandAccounts.Parameters.AddWithValue("@birthYear", birthYear);
            myCommmandAccounts.Parameters.AddWithValue("@favColour", favouriteColour);
            myCommmandAccounts.Parameters.AddWithValue("@favFood", favouriteFood);
            myCommmandAccounts.Parameters.AddWithValue("@favFoodColour", favouriteFoodColour);

            myCommmandAccounts.ExecuteNonQuery();
            myConnection.Close();

            textBoxDatabaseLastName.Text = "";
            textBoxDatabaseFirstName.Text = "";
            textBoxDatabasePassword.Text = "";
        }

        private void textBoxDatabaseBirthDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxDatabaseBirthMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxDatabaseBirthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
