using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Departments.Dto
{
    [AutoMapFrom(typeof(DepartmentDto))]
    [AutoMapTo(typeof(Department))]
    public class CreateDepartmentDto
    {
        public string DepartmentName { get; set; }
    }
}
