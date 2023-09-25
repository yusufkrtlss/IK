using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using IK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace IK.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IGenderService _genderService;
        private readonly ILogger<StaffController> _logger;
        public StaffController(IStaffService staffService, IMapper mapper, IDepartmentService departmentService, IGenderService genderService, ILogger<StaffController> logger)
        {
            _staffService = staffService;
            _mapper = mapper;
            _departmentService = departmentService;
            _genderService = genderService;
            _logger = logger;
        }
        // GET: Staff
        public async Task<IActionResult> Index(string departmentName, bool? status)
        {
            var staffList = await _staffService.GetStaffsWithDepartmentGenderAndComments();
            var staffDTOList = _mapper.Map<IEnumerable<StaffDTO>>(staffList);

            // Fetch the list of departments for the filter dropdown
            var departments = await _departmentService.TGetAllAsync();
            var departmentNames = departments.Select(d => d.DepartmentName).ToList();
            departmentNames.Insert(0, "Tüm");

            // Apply department filtering if a department name is provided
            if (!string.IsNullOrEmpty(departmentName) && departmentName != "Tüm")
            {
                staffDTOList = staffDTOList.Where(s => s.DepartmentName == departmentName);
            }
            // Filter staff by status if a status is provided
            if (status.HasValue)
            {
                staffDTOList = staffDTOList.Where(s => s.Status == status.Value);
            }

            ViewBag.Departments = departmentNames;
            return View(staffDTOList);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _staffService.TGetByIdAsync(id.Value);

            if (staff == null)
            {
                return NotFound();
            }
            await _staffService.LoadRelatedEntitiesAsync(staff);
            var staffDTO = _mapper.Map<StaffDTO>(staff);
            return View(staffDTO);
        }

        // GET: Staff/Create
        public async Task<IActionResult> Create()
        {
            var genders = await _genderService.TGetAllAsync();
            var departments = await _departmentService.TGetAllAsync();

            var viewModel = new StaffCreateViewModel
            {
                Genders = genders.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.GenderName
                }),
                Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DepartmentName
                })
            };

            return View(viewModel);
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the selected gender and department based on SelectedGenderId and SelectedDepartmentId
                int selectedGenderId = viewModel.SelectedGenderId;
                int selectedDepartmentId = viewModel.SelectedDepartmentId;

                // Use the selected gender and department IDs as needed when creating the Staff entity

                // Rest of your code for creating the Staff entity and redirecting

                return RedirectToAction("Index");
            }

            // Repopulate the Genders and Departments collections in case of validation errors
            var genders = await _genderService.TGetAllAsync();
            var departments = await _departmentService.TGetAllAsync();

            viewModel.Genders = genders.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.GenderName
            });

            viewModel.Departments = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.DepartmentName
            });

            return View(viewModel);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffService.TGetByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            // Retrieve the list of departments and genders
            var departments = await _departmentService.TGetAllAsync();
            var genders = await _genderService.TGetAllAsync();

            var viewModel = new StaffUpdateViewModel
            {
                UpdateStaff = _mapper.Map<UpdateStaffDTO>(staff),
                DepartmentList = new SelectList(departments, "DepartmentName", "DepartmentName"),
                GenderList = new SelectList(genders, "GenderName", "GenderName")
            };

            return View(viewModel);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the staff member from the database
                var staff = await _staffService.TGetByIdAsync(viewModel.UpdateStaff.Id);
                if (staff == null)
                {
                    return NotFound();
                }

                // Update staff attributes based on the UpdateStaffDTO
                _mapper.Map(viewModel.UpdateStaff, staff);

                // Retrieve the list of departments and genders using TGetAllAsync
                var departments = await _departmentService.TGetAllAsync();
                var genders = await _genderService.TGetAllAsync();

                viewModel.DepartmentList = new SelectList(departments, "DepartmentName", "DepartmentName");
                viewModel.GenderList = new SelectList(genders, "GenderName", "GenderName");

                // Save changes to the database
                await _staffService.TUpdateAsync(staff);

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, redisplay the form with validation errors
            viewModel.DepartmentList = new SelectList(new List<string>());
            viewModel.GenderList = new SelectList(new List<string>());

            return View(viewModel);
            //if (id != viewModel.UpdateStaff.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    var updateStaffDTO = viewModel.UpdateStaff;
            //    var genderId = updateStaffDTO.GenderId;

            //    var genderList = viewModel.GenderList.ToList();
            //    var selectedGender = genderList.FirstOrDefault(g => g.Value == genderId.ToString());

            //    if (selectedGender != null)
            //    {
            //        updateStaffDTO.GenderName = selectedGender.Text;
            //    }

            //    var staff = _mapper.Map<Staff>(updateStaffDTO);

            //    await _staffService.TUpdateAsync(staff);
            //    return RedirectToAction(nameof(Index));
            //}
            //viewModel.DepartmentList = new SelectList(await _departmentService.TGetAllAsync(), "Id", "DepartmentName");
            //viewModel.GenderList = new SelectList(await _genderService.TGetAllAsync(), "Id", "GenderName");
            //return View(viewModel);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _staffService.TGetByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff); // This view will not be displayed in the modal
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _staffService.TDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
