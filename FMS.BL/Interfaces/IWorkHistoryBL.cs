using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.BL.Interfaces
{
    interface IWorkHistoryBL
    {
        void AddWorkHistoryInfo(WorkHistory workHistory);
        void UpdWorkHistoryInfo(WorkHistory workHistory);
        ArrayList PrintWorkHistoryInfo(WorkHistory workHistory);
        void DelWorkHistoryInfo(WorkHistory workHistory);
    }



}
