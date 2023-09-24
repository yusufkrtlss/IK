using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Application : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public byte[] PdfData { get; set; } // CV okumak için !!
        public string FileName { get; set; } // CV ismi
        public DateTime ApplicationTime { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
