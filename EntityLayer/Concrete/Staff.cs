using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Concrete
{
    public class Staff : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public bool Status { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; } // Department Foreign Key
        public virtual Department Department { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; } // Gender Foreign Key
        public virtual Gender Gender { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        // Özel Alanlar
        public string Ozel_Alan1 { get; set; }
        public string Ozel_Alan2 { get; set; }
        public string Ozel_Alan3 { get; set; }
        public string Ozel_Alan4 { get; set; }
        public string Ozel_Alan5 { get; set; }
        public string Ozel_Alan6 { get; set; }
        public string Ozel_Alan7 { get; set; }
        public string Ozel_Alan8 { get; set; }
        public string Ozel_Alan9 { get; set; }
        public string Ozel_Alan10 { get; set; }
    }
}
