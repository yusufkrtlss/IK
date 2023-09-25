using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class EFStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public async Task<IEnumerable<Staff>> GetStaffsWithDepartmentGenderAndComments()
        {
            using var c = new StoreContext();
            return await c.Staffs.Include(s => s.Department).Include(c => c.Comment).Include(g => g.Gender).ToListAsync();
        }

        public async Task LoadRelatedEntitiesAsync(Staff staff)
        {
            using var _dbContext = new StoreContext();
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            var entry = _dbContext.Entry(staff);

            if (entry.State == EntityState.Detached)
            {
                // If the entity is detached, re-attach it to the DbContext
                _dbContext.Attach(staff);
            }

            // Load related entities (Department, Gender, Comments)
            await entry.Reference(s => s.Department).LoadAsync();
            await entry.Reference(s => s.Gender).LoadAsync();
            await entry.Reference(s => s.Comment).LoadAsync();
        }
    }
}
