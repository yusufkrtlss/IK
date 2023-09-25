using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IK.Models
{
    public class StaffUpdateViewModel
    {
        public UpdateStaffDTO UpdateStaff { get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList GenderList { get; set; }
    }
}
