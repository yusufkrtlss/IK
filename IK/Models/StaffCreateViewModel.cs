using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IK.Models
{
    public class StaffCreateViewModel
    {
        public AddStaffDTO AddStaff { get; set; }
        public int SelectedGenderId { get; set; }
        public int SelectedDepartmentId { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
