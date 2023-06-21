using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Departments.Dto
{
    [AutoMapFrom(typeof(Department))]
    [AutoMapTo(typeof(Department))]
    public class DepartmentDto : EntityDto<int>
    {
        public string DepartmentName { get; set; }
    }
}
