using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.BookCategory;
using LibrarySystemAdrienne.BookCategory.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Departments;
using LibrarySystemAdrienne.Web.Models.BookCategories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{
    public class BooksCategoriesController : LibrarySystemAdrienneControllerBase
    {
        private IBookCategoryAppService _categoryIAppService;
        private IDepartmentAppService _departmentIAppService;

        public BooksCategoriesController(IBookCategoryAppService categoryIAppService, IDepartmentAppService departmentIAppService)
        {
            _categoryIAppService = categoryIAppService;
            _departmentIAppService = departmentIAppService;
        }

        #region Category Index Page View
        public async Task<IActionResult> Index(string searchCategory)
        {
            var category = await _categoryIAppService.GetAllBookCategoryWithDepartment(new PagedBookCategoryResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new BookCategoryListViewModel();

            if (searchCategory != null)
            {
                model = new BookCategoryListViewModel()
                {
                    BookCategories = category.Items.Where(input =>
                    input.Id!.ToString().Contains(searchCategory) ||
                    input.Department.DepartmentName!.ToString().Contains(searchCategory) ||
                    input.CategoryName!.Contains(searchCategory)).ToList(),
                };
            }
            else
            {
                model = new BookCategoryListViewModel()
                {
                    BookCategories = category.Items.ToList(),
                };
            }

            return View(model);


        }
        [HttpGet]
        #endregion

        #region Category Create or Edit Page View
        public async Task<IActionResult> CreateOrEditBookCategory(int id)
        {
            var model = new CreateOrEditBookCategoryViewModel();
            var departments = await _departmentIAppService.GetAllDepartments(); //galing sa app service to end point here at controller 

            if (id != 0)
            {
                var category = await _categoryIAppService.GetAsync(new EntityDto<int>(id));

                model = new CreateOrEditBookCategoryViewModel()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    DepartmentId = category.DepartmentId,
                };
            }

            model.Departments = departments;

            return View(model);
        }
        #endregion

    }
}
