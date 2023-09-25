using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string Tc { get; set; } // Kimlik kart numarası
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int DepartmentId { get; set; }
        public int GenderId { get; set; }
        public string DepartmentName { get; set; } // Added for displaying department name
        public string GenderName { get; set; }
    }
}
