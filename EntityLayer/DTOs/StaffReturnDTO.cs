using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class StaffReturnDTO
    {
        public List<Staff> Staff { get; set; }
        public List<Department> Department { get; set; }
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Department { get; set; }
        //public bool Status { get; set; }
    }
}
