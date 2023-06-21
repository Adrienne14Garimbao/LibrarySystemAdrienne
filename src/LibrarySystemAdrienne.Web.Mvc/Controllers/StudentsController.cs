using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Departments;
using LibrarySystemAdrienne.Students;
using LibrarySystemAdrienne.Students.Dto;
using LibrarySystemAdrienne.Web.Models.Students;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{
    public class StudentsController : LibrarySystemAdrienneControllerBase
    {

        //public List<StudentDto> Students { get; private set; }

        private IStudentAppService _studentIAppService; 
        private IDepartmentAppService _departmentIAppService;

        public StudentsController(IStudentAppService studentIAppService, IDepartmentAppService departmentIAppService)
        {
            _studentIAppService = studentIAppService;
            _departmentIAppService = departmentIAppService;
        }  

        #region Student Index Page View
        public async Task<IActionResult> Index(string searchStudent)
        {
            var students = await _studentIAppService.GetAllStudentWithDepartment(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new StudentListViewModel();

            if (searchStudent != null)
            {
                model = new StudentListViewModel()
                {
                    Students = students.Items.Where(input =>
                       input.StudentName!.ToString().Contains(searchStudent) ||
                       input.Id!.ToString().Contains(searchStudent) ||
                       input.StudentContactNumber!.ToString().Contains(searchStudent) ||
                       input.Department.DepartmentName.ToString().Contains(searchStudent) ||
                       input.StudentEmail!.Contains(searchStudent))
                    .ToList(),
                };
            }
            else
            {
                model = new StudentListViewModel()
                {
                    Students = students.Items.ToList(),
                };
            }

            return View(model);

        }
        [HttpGet]
        #endregion

        #region Students Create or Edit Page View
        public async Task<IActionResult> CreateOrEditStudent(int id)
        {
            var model = new CreateOrEditStudentViewModel();
            var departments = await _departmentIAppService.GetAllDepartments(); //end point interface

            if (id != 0)
            {
                var student = await _studentIAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditStudentViewModel()
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    StudentContactNumber = student.StudentContactNumber,
                    StudentEmail = student.StudentEmail,
                    DepartmentId = student.DepartmentId,
                };
            }

            model.Departments = departments;
            return View(model);
        }
        #endregion


    }
}
