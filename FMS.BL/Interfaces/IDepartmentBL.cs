using System.Text;
using System.Threading.Tasks;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.BL.Interfaces
{
    interface IDepartmentBL
    {
        void AddDepartment(Department newdept);
    }
}
