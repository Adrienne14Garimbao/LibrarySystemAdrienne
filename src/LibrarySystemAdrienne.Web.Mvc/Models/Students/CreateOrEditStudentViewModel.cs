using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using System.Collections.Generic;

namespace LibrarySystemAdrienne.Web.Models.Students
{
    public class CreateOrEditStudentViewModel
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public long StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public List<DepartmentDto> Departments { get; set; }    


    }
}
