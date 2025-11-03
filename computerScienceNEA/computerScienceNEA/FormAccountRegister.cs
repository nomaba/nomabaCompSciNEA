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
            

            int favouriteColourID = 0;
            int foodColourID = 0;
            int favouriteFoodID = 0;

            progressBar.Value = 5;

            //link database
            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db"); // Connect to the database at this location

            progressBar.Value = 7;


            if (int.TryParse(textBoxDatabaseBirthDay.Text, out int day) &&
                int.TryParse(textBoxDatabaseBirthMonth.Text, out int month) &&
                day >= 1 && day <= 31 &&
                month >= 1 && month <= 12 &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseFirstName.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseLastName.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabasePassword.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseUsername.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseFavouriteColour.Text) &&
                !string.IsNullOrWhiteSpace(textBoxDatabaseFavouriteFood.Text) &&
                !string.IsNullOrWhiteSpace(textBoxFavouriteFoodColour.Text))
            {
                //Date inputted is valid

                string firstName = textBoxDatabaseFirstName.Text;
                string lastName = textBoxDatabaseLastName.Text;
                string password = textBoxDatabasePassword.Text;
                string username = textBoxDatabaseUsername.Text;
                int birthDay = int.Parse(textBoxDatabaseBirthDay.Text);
                int birthMonth = int.Parse(textBoxDatabaseBirthMonth.Text);
                int birthYear = int.Parse(textBoxDatabaseBirthYear.Text);
                string favouriteColour = textBoxDatabaseFavouriteColour.Text;
                string favouriteFood = textBoxDatabaseFavouriteFood.Text;
                string favouriteFoodColour = textBoxFavouriteFoodColour.Text;


                string queryCheckUsernameExists = "SELECT accountID FROM accounts WHERE username = @username";
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

                    //works dont touch
                    string queryCheckColourExists = "SELECT colourName FROM colours WHERE colourName = @favColour";
                    SQLiteCommand myCommmandCheckColourExists = new SQLiteCommand(queryCheckColourExists, myConnection); // Created new variable that stores the query
                    myCommmandCheckColourExists.Parameters.AddWithValue("@favColour", favouriteColour);
                    SQLiteDataReader resultCheckColourExists = myCommmandCheckColourExists.ExecuteReader();
                    if (resultCheckColourExists.Read())
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        string queryColours = "INSERT INTO colours(colourName) values (@favColour)";
                        SQLiteCommand myCommmandColours = new SQLiteCommand(queryColours, myConnection); // Created new variable that stores the query
                        myCommmandColours.Parameters.AddWithValue("@favColour", favouriteColour);
                        myCommmandColours.ExecuteNonQuery();
                    }
                    //above works dont touch


                    progressBar.Value = 20;
                    


                    System.Threading.Thread.Sleep(2000);
                    string queryFindColourID = "SELECT colourID FROM colours WHERE colourName = @favColour";
                    SQLiteCommand myCommmandFindColourID = new SQLiteCommand(queryFindColourID, myConnection); // Created new variable that stores the query
                    myCommmandFindColourID.Parameters.AddWithValue("@favColour", favouriteColour);
                    myCommmandFindColourID.ExecuteNonQuery();
                    favouriteColourID = Convert.ToInt32(myCommmandFindColourID.ExecuteScalar());


                    progressBar.Value = 40;


                    System.Threading.Thread.Sleep(2000);
                    string queryFindFoodColourID = "SELECT colourID FROM colours WHERE colourName = @foodColour";
                    SQLiteCommand myCommmandFindFoodColourID = new SQLiteCommand(queryFindFoodColourID, myConnection); // Created new variable that stores the query
                    myCommmandFindFoodColourID.Parameters.AddWithValue("@foodColour", favouriteFoodColour);
                    myCommmandFindFoodColourID.ExecuteNonQuery();
                    foodColourID = Convert.ToInt32(myCommmandFindFoodColourID.ExecuteScalar());

                    progressBar.Value = 45;


                    //works dont touch
                    string queryCheckFoodExists = "SELECT foodName FROM foods WHERE foodName = @favFood";
                    SQLiteCommand myCommmandCheckFoodExists = new SQLiteCommand(queryCheckFoodExists, myConnection); // Created new variable that stores the query
                    myCommmandCheckFoodExists.Parameters.AddWithValue("@favFood", favouriteFood);
                    SQLiteDataReader resultCheckFoodExists = myCommmandCheckFoodExists.ExecuteReader();
                    if (resultCheckFoodExists.Read())
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        string queryAddNewFood = "INSERT INTO foods(foodName, foodColour) values (@foodName, @foodColour)";
                        SQLiteCommand myCommmandFood = new SQLiteCommand(queryAddNewFood, myConnection); // Created new variable that stores the query
                        myCommmandFood.Parameters.AddWithValue("@foodName", favouriteFood);
                        myCommmandFood.Parameters.AddWithValue("@foodColour", foodColourID);
                        myCommmandFood.ExecuteNonQuery();
                    }
                    //above works dont touch

                    System.Threading.Thread.Sleep(2000);
                    string queryFindFoodID = "SELECT foodID FROM foods WHERE foodName = @favFood";
                    SQLiteCommand myCommmandFindFoodID = new SQLiteCommand(queryFindFoodID, myConnection); // Created new variable that stores the query
                    myCommmandFindFoodID.Parameters.AddWithValue("@favFood", favouriteFood);
                    myCommmandFindFoodID.ExecuteNonQuery();
                    favouriteFoodID = Convert.ToInt32(myCommmandFindFoodID.ExecuteScalar());


                    progressBar.Value = 80;

                    //write query
                    string queryAccounts = "INSERT INTO accounts(firstName, lastName, password, username, birthDay, birthMonth, birthYear, favColour, favFood, LV) values (@firstName, @lastName, @password, @username, @birthDay, @birthMonth, @birthYear, @favColour, @favFood, 50)";
                    SQLiteCommand myCommmandAccounts = new SQLiteCommand(queryAccounts, myConnection); // Created new variable that stores the query


                    //elecute command
                    myCommmandAccounts.Parameters.AddWithValue("@firstName", firstName);
                    myCommmandAccounts.Parameters.AddWithValue("@lastName", lastName);
                    myCommmandAccounts.Parameters.AddWithValue("@password", password);
                    myCommmandAccounts.Parameters.AddWithValue("@username", username);
                    myCommmandAccounts.Parameters.AddWithValue("@birthDay", birthDay);
                    myCommmandAccounts.Parameters.AddWithValue("@birthMonth", birthMonth);
                    myCommmandAccounts.Parameters.AddWithValue("@birthYear", birthYear);
                    myCommmandAccounts.Parameters.AddWithValue("@favColour", favouriteColourID);
                    myCommmandAccounts.Parameters.AddWithValue("@favFood", favouriteFoodID);

                    myCommmandAccounts.ExecuteNonQuery();
                    myConnection.Close();


                    progressBar.Value = 100;
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
                    textBoxDatabaseFavouriteColour.Text = "";

                    MessageBox.Show("You have registered successfully. Please Log in to your account again"); // just read the text behind me

                    FormAccountLogin FormAccountLogin = new FormAccountLogin();
                    this.Hide();
                    FormAccountLogin.Show();
                }
            }
            else
            {
                MessageBox.Show("One or more of the data you inputted is invaled. Please ensure that you have filled all boxes and a valid date has been provided"); // just read the text behind me
            }

            progressBar.Value = 0;

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

        private void FormAccountRegister_Load(object sender, EventArgs e)
        {

        }
    }
}

















