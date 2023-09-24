using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
