using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IK.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public StaffController(IStaffService staffService, IMapper mapper, IDepartmentService departmentService)
        {
            _staffService = staffService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public IActionResult Personel()
        {
            
            var dep = _departmentService.TGetList();
            var values = _staffService.TGetList();
            var model = new StaffReturnDTO()
            {
                Department = dep,
                Staff = values,
            };
            return View(model);
        }
    }
}
