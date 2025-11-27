using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace computerScienceNEA
{
    class LV
    {
        // use inheritance to manage the love value here
        protected int accountID;
        protected string firstName;
        protected string  lastName;
        protected string username;
        protected int birthDay;
        protected int birthMonth;
        protected int birthYear;
        protected int favColourID;
        protected int favFoodID;
        protected int LVe;
        protected int PreviousStateID;


        public LV(int accountIDLocal, string firstNameLocal, string lastNameLocal, string usernameLocal, int birthDayLocal, int birthMonthLocal, int birthYearLocal, int favColourIDLocal, int favFoodIDLocal, int LVeLocal, int previousStateIDLocal)
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
            this.PreviousStateID = previousStateIDLocal;
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
        public string getFavColour()
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
        public string getPreviousState()
        {
            string previousState = "null";

            SQLiteConnection myConnection; //created new vatiable callled my connection
            myConnection = new SQLiteConnection("Data Source=database.db");

            string queryGetPreviousState = "SELECT stateName FROM robotStates WHERE stateID = @stateID";

            SQLiteCommand myCommmandGetPreviousState = new SQLiteCommand(queryGetPreviousState, myConnection);
            myCommmandGetPreviousState.Parameters.AddWithValue("@stateID", PreviousStateID);

            myConnection.Open();
            SQLiteDataReader State = myCommmandGetPreviousState.ExecuteReader();
            while (State.Read())
            {
                previousState = State.GetString(0);
            }
            myConnection.Close();

            return previousState;
        }












        public void updatePassword()
        {

        }
        public void updateFavColour()
        {

        }
        public void updateFavFood()
        {

        }
        public void updateLV()
        {

        }
        public void updatePreviousState()
        {

        }

    }
}
