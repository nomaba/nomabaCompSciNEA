using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computerScienceNEA
{
    class LV
    {
        // use inheritance to manage the love value here
        protected string username;
        protected int accountID;
        protected string firstName;
        protected bool lastName;
        protected int LVe;


        public LV(string usernameLocal, int accountIDLocal, string firstNameLocal, bool lastNameLocal, int LVeLocal)
        {
            this.username = usernameLocal;
            this.accountID = accountIDLocal;
            this.firstName = firstNameLocal;
            this.lastName = lastNameLocal;
            this.LVe = LVeLocal;
        }
    }
}
