using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace computerScienceNEA
{
    public class LV
    {
        // use inheritance to manage the love value and other fields in the database here
        protected int accountID; // Can't update
        protected string firstName; // Can update
        protected string  lastName; // Can update
        protected string username; // Can't update
        protected int birthDay; // Can't update
        protected int birthMonth; // Can't update
        protected int birthYear; // Can't update
        protected int favColourID; // Can update
        protected int favFoodID; // Can update
        protected int LVe; // Can update
        protected int? favGameID; // Can update // the question mark allows it to store null values


        public LV(int accountIDLocal, string firstNameLocal, string lastNameLocal, string usernameLocal, int birthDayLocal, int birthMonthLocal, int birthYearLocal, int favColourIDLocal, int favFoodIDLocal, int LVeLocal, int? favGameIDLocal)
        {
            this.accountID = accountIDLocal;
            this.firstName = firstNameLocal;
            this.lastName = lastNameLocal;
            this.username = usernameLocal;
            this.birthDay = birthDayLocal;
            this.birthMonth = birthMonthLocal;
            this.birthYear = birthYearLocal;
            this.favColourID = favColourIDLocal;
            this.favFoodID = favFoodIDLocal;
            this.LVe = LVeLocal;
            this.favGameID = favGameIDLocal;
        }

        

        public int getAccountID()
        {
            return accountID;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getUsername()
        {
            return username;
        }
        public string getDOBddmmyyyy()
        {
            string DOB = birthDay.ToString() + "/" + birthMonth.ToString() + "/" + birthYear.ToString();
            return DOB;
        }
        public int getBirthDay()
        {
            return birthDay;
        }
        public int getBirthMonth()
        {
            return birthMonth;
        }
        public int getBirthYear()
        {
            return birthYear;
        }
        public string getFavColour() // gets the colourName from the database because the object only has the ColourID
        {
            string colour = "null";


            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryGetFavColour = "SELECT colourName FROM colours WHERE ColourID = @ColourID";

            SQLiteCommand myCommmandGetFavColour = new SQLiteCommand(queryGetFavColour, myConnection);
            myCommmandGetFavColour.Parameters.AddWithValue("@ColourID", favColourID);

            myConnection.Open();
            SQLiteDataReader favColour = myCommmandGetFavColour.ExecuteReader();
            while (favColour.Read())
            {
                colour = favColour.GetString(0);
            }
            myConnection.Close();

            return colour;
        }
        public string getFavFood()
        {
            string food = "null";


            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryGetFavFood = "SELECT foodName FROM foods WHERE foodID = @foodID";

            SQLiteCommand myCommmandGetFavFood = new SQLiteCommand(queryGetFavFood, myConnection);
            myCommmandGetFavFood.Parameters.AddWithValue("@foodID", favFoodID);

            myConnection.Open();
            SQLiteDataReader favFood = myCommmandGetFavFood.ExecuteReader();
            while (favFood.Read())
            {
                food = favFood.GetString(0);
            }
            myConnection.Close();

            return food;
        }
        public int getLV()
        {
            return LVe;
        }
        public int? getfavGameID()
        {
            return favGameID;
        }











        public void updatePassword(string newPassword)
        {

            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryupdatePassword = "UPDATE accounts SET password = @password WHERE accountID = @accountID";

            SQLiteCommand myCommmandupdatePassword = new SQLiteCommand(queryupdatePassword, myConnection);
            myCommmandupdatePassword.Parameters.AddWithValue("@password", newPassword);

            myConnection.Open();
            myCommmandupdatePassword.ExecuteNonQuery();
            myConnection.Close();
        }

        public void updateFavColour(string newFavColour)
        {
            int newFavColourID;

            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");


            string queryCheckColourExists = "SELECT colourName FROM colours WHERE colourName = @favColour";
            SQLiteCommand myCommmandCheckColourExists = new SQLiteCommand(queryCheckColourExists, myConnection); // Created new variable that stores the query
            myCommmandCheckColourExists.Parameters.AddWithValue("@favColour", newFavColour);
            myConnection.Open();
            SQLiteDataReader resultCheckColourExists = myCommmandCheckColourExists.ExecuteReader();
            if (resultCheckColourExists.Read())
            {
                // colour exists in database
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                // colour not exist in databse
                System.Threading.Thread.Sleep(2000);
                string queryColours = "INSERT INTO colours(colourName) values (@favColour)";
                SQLiteCommand myCommmandColours = new SQLiteCommand(queryColours, myConnection); // Created new variable that stores the query
                myCommmandColours.Parameters.AddWithValue("@favColour", newFavColour);
                myCommmandColours.ExecuteNonQuery();
            }
            //above works dont touch
            // The above checks if the colour exists in the databse and if it doestnn then it adds the colour in the databse





            System.Threading.Thread.Sleep(2000);
            string queryFindColourID = "SELECT colourID FROM colours WHERE colourName = @favColour";
            SQLiteCommand myCommmandFindColourID = new SQLiteCommand(queryFindColourID, myConnection); // Created new variable that stores the query
            myCommmandFindColourID.Parameters.AddWithValue("@favColour", newFavColour);
            myCommmandFindColourID.ExecuteNonQuery();
            newFavColourID = Convert.ToInt32(myCommmandFindColourID.ExecuteScalar());
            // the above gets the colourID and stores it in a variable




            System.Threading.Thread.Sleep(2000);
            string queryUpdateFavColour = "UPDATE accounts SET favColour = @favColour WHERE accountID = @accountID";
            SQLiteCommand myCommmandUpdateFavColour = new SQLiteCommand(queryUpdateFavColour, myConnection); // Created new variable that stores the query
            myCommmandUpdateFavColour.Parameters.AddWithValue("@favColour", newFavColourID);
            myCommmandUpdateFavColour.ExecuteNonQuery();
            myConnection.Close();

            favColourID = newFavColourID;




        }
        public void updateLV(int ammount)
        {
            int newLVe = LVe + ammount;

            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryupdateLV = "UPDATE accounts SET LV = @LV WHERE accountID = 0";

            SQLiteCommand myCommmandupdateLV = new SQLiteCommand(queryupdateLV, myConnection);
            myCommmandupdateLV.Parameters.AddWithValue("@LV", newLVe);

            myConnection.Open();
            myCommmandupdateLV.ExecuteNonQuery();
            myConnection.Close();

            LVe = newLVe;
        }
        public void updateFavGameID(int game)
        {
            favGameID = game;

            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryupdateFavGameID = "UPDATE accounts SET favGameID = @favGameID WHERE accountID = @accountID";

            SQLiteCommand myCommmandupdateFavGameID = new SQLiteCommand(queryupdateFavGameID, myConnection);
            myCommmandupdateFavGameID.Parameters.AddWithValue("@favGameID", game);
            myCommmandupdateFavGameID.Parameters.AddWithValue("@accountID", accountID);

            myConnection.Open();
            try
            {
                myCommmandupdateFavGameID.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("database is locked"))
                {
                    FormSettings FormSettings = new FormSettings();
                    FormSettings.showMessageBox("Database is busy. Please try again. later");
                }
                else
                {
                    throw; // try again
                }
            }

            myConnection.Close();
        }

    }
}
