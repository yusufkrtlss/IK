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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public async Task TAddAsync(Department entity)
        {
            await _departmentDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _departmentDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Department>> TGetAllAsync()
        {
            return await _departmentDal.GetAllAsync();
        }

        public async Task<Department> TGetByIdAsync(int id)
        {
            return await _departmentDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Department entity)
        {
            await _departmentDal.UpdateAsync(entity);
        }
    }
}
