using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Students.Dto
{
    [AutoMapTo(typeof(Student))]

    public class CreateStudentDto
    {
        public string StudentName { get; set; }

        public long StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }
    }
}
