using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    [AutoMapTo(typeof(Student))]
    public class StudentDto : EntityDto<int>
    {
        public string StudentName { get; set; }

        public long StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
