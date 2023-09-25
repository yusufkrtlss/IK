using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task<IEnumerable<Staff>> GetStaffsWithDepartmentGenderAndComments()
        {
            return await _staffDal.GetStaffsWithDepartmentGenderAndComments();
        }

        public async Task LoadRelatedEntitiesAsync(Staff staff)
        {
            await _staffDal.LoadRelatedEntitiesAsync(staff);
        }

        public async Task TAddAsync(Staff entity)
        {
            await _staffDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _staffDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Staff>> TGetAllAsync()
        {
            return await _staffDal.GetAllAsync();
        }

        public async Task<Staff> TGetByIdAsync(int id)
        {
            return await _staffDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Staff entity)
        {
            await _staffDal.UpdateAsync(entity);
        }
    }
}
