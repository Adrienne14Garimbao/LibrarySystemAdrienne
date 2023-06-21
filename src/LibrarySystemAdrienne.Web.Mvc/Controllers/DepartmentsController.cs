using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Departments;
using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Web.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{

    public class DepartmentsController : LibrarySystemAdrienneControllerBase
    {

        private readonly IDepartmentAppService _departmentIAppService;

        public DepartmentsController(IDepartmentAppService departmentIAppService)
        {
            _departmentIAppService = departmentIAppService;
        }


        #region Department Index Page View
        public async Task<IActionResult> Index(string searchDepartment)
        {
            var department = await _departmentIAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new DepartmentListViewModel();

            if (searchDepartment != null)
            {
                model = new DepartmentListViewModel()
                {
                    Departments = department.Items.Where(input => input.Id!.ToString().Contains(searchDepartment) || input.DepartmentName!.Contains(searchDepartment)).ToList(),
                };
            }
            else
            {
                model = new DepartmentListViewModel()

                {
                    Departments = department.Items.ToList(),
                };
            }


            return View(model);


        }
        [HttpGet]
        #endregion

        #region Departments Create or Edit Page View
        public async Task<IActionResult> CreateOrEditDepartment(int id)
        {
            if (id != 0)
            {
                var department = await _departmentIAppService.GetAsync(new EntityDto<int>(id));

                var model = new CreateOrEditDepartmentViewModel()
                {
                    DepartmentName = department.DepartmentName,
                    Id = id

                };

                return View(model);
            }
            else
            {
                return View();

            }

        }
        #endregion
    }
}
