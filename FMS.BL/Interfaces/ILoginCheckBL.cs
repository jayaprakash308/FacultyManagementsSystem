using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.DAL;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;

namespace FMS.BL.Interfaces
{
    interface ILoginCheckBL
    {
        int LoginCheck(Users user);

    }
}
