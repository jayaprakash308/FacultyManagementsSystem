using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{
    //properties of publications
    public class Publications
    {
        public int PublicationID { get; set; }
        public int FacultyID { get; set; }
        public string PublicationTitle { get; set; }
        public string ArticleName { get; set; }
        public string PublisherName { get; set; }
        public string PublicationLocation { get; set; }
        public DateTime CitationDate { get; set; }

        //constructor of publications
        public Publications()
        {
          
        }

    }
}