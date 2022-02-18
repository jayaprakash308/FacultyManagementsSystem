using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.BL.Interfaces
{
    interface IPublicationBL
    {
        void AddPublications(Publications publication);
        void UpdPublications(Publications publication);
        void DelPublications(Publications publication);
        ArrayList PrintPublications(Publications publication);
        ArrayList PrintPubicationsYear(string year);
        ArrayList PrintPubicationsMonth(string month);
        ArrayList PrintPubicationsRecent(string recent);

    }
}
