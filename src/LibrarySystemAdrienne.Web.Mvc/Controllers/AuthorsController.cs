using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Authors;
using LibrarySystemAdrienne.Authors.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using LibrarySystemAdrienne.Students.Dto;
using LibrarySystemAdrienne.Web.Models.Authors;
using LibrarySystemAdrienne.Web.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{
    public class AuthorsController : LibrarySystemAdrienneControllerBase
    {

        private readonly IAuthorAppService _authorIAppService;

        public AuthorsController(IAuthorAppService authorIAppService)
        {
            _authorIAppService = authorIAppService;
        }

        #region Author Index Page View
        public async Task<IActionResult> Index(string searchAuthor)
        {
            var author = await _authorIAppService.GetAllAsync(new PagedAuthorResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new AuthorListViewModel();

            if (searchAuthor != null)
            {
                model = new AuthorListViewModel()
                {
                    Authors = author.Items.Where(input => input.Id!.ToString().Contains(searchAuthor) || input.AuthorName!.Contains(searchAuthor)).ToList()
                };
            }
            else
            {
                model = new AuthorListViewModel()
                {
                    Authors = author.Items.ToList(),
                };
            }

            return View(model);
        }
        [HttpGet]
        #endregion

        #region Author Create or Edit Page View
        public async Task<IActionResult> CreateOrEditAuthor(int id)
        {
            if (id != 0)
            {
                var author = await _authorIAppService.GetAsync(new EntityDto<int>(id));

                var model = new CreateOrEditAuthorViewModel()
                {
                    AuthorName = author.AuthorName,
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
