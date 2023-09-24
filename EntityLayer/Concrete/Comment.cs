using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }

        // Özel Alanlar
        public string Ozel_Alan11 { get; set; }
        public string Ozel_Alan12 { get; set; }
        public string Ozel_Alan13 { get; set; }
        public string Ozel_Alan14 { get; set; }
        public string Ozel_Alan15 { get; set; }
    }
}
