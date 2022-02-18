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
using FMS.BL.Interfaces;

namespace FMS.BL
{
    public class WorkHistoryBL : IWorkHistoryBL
    {
        void IWorkHistoryBL.AddWorkHistoryInfo(WorkHistory workHistory)
        {
           
        }

        void IWorkHistoryBL.DelWorkHistoryInfo(WorkHistory workHistory)
        {
            
        }

        ArrayList IWorkHistoryBL.PrintWorkHistoryInfo(WorkHistory workHistory)
        {
            throw new NotImplementedException();
        }

        void IWorkHistoryBL.UpdWorkHistoryInfo(WorkHistory workHistory)
        {
            throw new NotImplementedException();
        }
    }
}