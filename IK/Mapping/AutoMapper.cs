using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace IK.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Staff, StaffReturnDTO>()
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department.DepartmentName));
        }
    }
}
