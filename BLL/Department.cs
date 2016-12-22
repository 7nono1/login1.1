using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Department
    {
        public static DataTable getDepartment( string Name)
        {
            return DAL.DBHelper.getDt("SELECT distinct 部门 FROM 教师 WHERE 姓名='" + Name + "' ");
        }
    }
}
