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

            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location

            
            bool validUserInput = false;

            if (int.Parse(textBoxDatabaseBirthDay.Text) >= 1 &&
                int.Parse(textBoxDatabaseBirthDay.Text) <= 31 &&
                int.Parse(textBoxDatabaseBirthMonth.Text) >= 1 &&
                int.Parse(textBoxDatabaseBirthMonth.Text) <= 12)
            {
                //Date inputted is valid




                string queryCheckUsernameExists = "SELECT accountID FROM accounts WHERE username = @username AND password = @password";
                SQLiteCommand myCommmandCheckUsernameExists = new SQLiteCommand(queryCheckUsernameExists, myConnection);

                myConnection.Open();

                myCommmandCheckUsernameExists.Parameters.AddWithValue("@username", username);

                SQLiteDataReader result = myCommmandCheckUsernameExists.ExecuteReader();
                if (result.Read())
                {
                    MessageBox.Show("This username is used by someone else"); // just read the text behind me
                }
                else
                {
                    // Username is not used by someone else


                }
            }



           











            //write query
            string queryAccounts = "INSERT INTO accounts(firstName, lastName, password, username, birthDay, birthMonth, birthYear, favColour, favFood) values (@firstName, @lastName, @password, @username, @birthDay, @birthMonth, @birthYear, @favColour, @favFood)";
            SQLiteCommand myCommmandAccounts = new SQLiteCommand(queryAccounts, myConnection); // Created new variable that stores the query

            


            //works dont touch
            string queryCheckColourExists = "SELECT colourName FROM colours WHERE colourName = @favColour";
            SQLiteCommand myCommmandCheckColourExists = new SQLiteCommand(queryCheckColourExists, myConnection); // Created new variable that stores the query
            myCommmandCheckColourExists.Parameters.AddWithValue("@favColour", textBoxDatabaseFavouriteColour.Text);
            SQLiteDataReader resultCheckColourExists = myCommmandCheckColourExists.ExecuteReader();
            if (resultCheckColourExists.Read())
            {
                System.Threading.Thread.Sleep(5000);
            }
            else
            {
                System.Threading.Thread.Sleep(5000);
                string queryColours = "INSERT INTO colours(colourName) values (@favColour)";
                SQLiteCommand myCommmandColours = new SQLiteCommand(queryColours, myConnection); // Created new variable that stores the query
                myCommmandColours.Parameters.AddWithValue("@favColour", textBoxDatabaseFavouriteColour.Text);
                myCommmandColours.ExecuteNonQuery();          
            }


            //above works dont touch

            //works dont touch
            string queryCheckFoodExists = "SELECT foodID FROM foods WHERE foodName = @favFood";
            SQLiteCommand myCommmandCheckFoodExists = new SQLiteCommand(queryCheckFoodExists, myConnection); // Created new variable that stores the query
            myCommmandCheckFoodExists.Parameters.AddWithValue("@favFood", textBoxDatabaseFavouriteColour.Text);
            SQLiteDataReader resultCheckFoodExists = myCommmandCheckFoodExists.ExecuteReader();
            System.Threading.Thread.Sleep(5000);
            if (resultCheckFoodExists.Read())
            {
                // do nothing
            }
            else
            {
                string queryAddNewFood = "INSERT INTO foods(foodName, foodColour) values (@foodName, @foodColour)";
                SQLiteCommand myCommmandFood = new SQLiteCommand(queryAddNewFood, myConnection); // Created new variable that stores the query
                myCommmandFood.Parameters.AddWithValue("@foodName", textBoxDatabaseFavouriteFood.Text);
                //.Parameters.AddWithValue("@foodColour", textBoxFavouriteFoodColour.Text);
                myCommmandFood.ExecuteNonQuery();
                System.Threading.Thread.Sleep(5000);

            }
            //above works dont touch








            //elecute command

            


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



            textBoxDatabaseFirstName.Text = "";
            textBoxDatabaseLastName.Text = "";
            textBoxDatabasePassword.Text = "";
            textBoxDatabaseUsername.Text = "";
            textBoxDatabaseBirthDay.Text = "";
            textBoxDatabaseBirthMonth.Text = "";
            textBoxDatabaseBirthYear.Text = "";
            textBoxDatabaseFavouriteColour.Text = "";
            textBoxDatabaseFavouriteFood.Text = "";
            textBoxDatabaseFavouriteFood.Text = "";
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

















