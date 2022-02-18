using System;

namespace FMS.Entity
{
    public class Faculty
    {
        //properties of faculty
        public int FacultyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string MoblieNo { get; set; }
        public DateTime HireDate { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateofBirth { get; set; }
        public int DeptID { get; set; }
        public int DesignationID { get; set; }

        //constructor of faculty
        public Faculty()
        {
           


        }

    }
}

