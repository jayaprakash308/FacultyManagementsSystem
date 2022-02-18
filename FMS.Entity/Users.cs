using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{

    public class Users
    {
        public int UserID;
        public string UserName;
        public string Password;
        public string usertype;
        private int universalID;


        //properties of users
        public int UserID1 { get => UserID; set => UserID = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Usertype { get => usertype; set => usertype = value; }
        public int UniversalID { get => universalID; set => universalID = value; }
    }
}