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
    public partial class FormAccountLogin : Form
    {
        public FormAccountLogin()
        {
            InitializeComponent();
        }

        private void FormAccountLogin_Load(object sender, EventArgs e)
        {

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
