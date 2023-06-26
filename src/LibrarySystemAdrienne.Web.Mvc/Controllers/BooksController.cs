using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Authors;
using LibrarySystemAdrienne.BookCategory;
using LibrarySystemAdrienne.Books;
using LibrarySystemAdrienne.Books.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Departments;
using LibrarySystemAdrienne.Web.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{
    public class BooksController : LibrarySystemAdrienneControllerBase
    {

        private IBookAppService _bookIAppService;
        private IBookCategoryAppService _categoryIAppService;
        private IAuthorAppService _authorIAppService;

        public BooksController(IBookAppService bookIAppService, IBookCategoryAppService categoryIAppService, IAuthorAppService authorIAppService)
        {
            _bookIAppService = bookIAppService;
            _categoryIAppService = categoryIAppService;
            _authorIAppService = authorIAppService;
        }

        #region Book Index Page View
        public async Task<IActionResult> Index(string searchBook)
        {

            var book = await _bookIAppService.GetAllBookWithCategoryAndAuthor(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue, SearchBook = searchBook });
            
            var model = new BookListViewModel();


            if (searchBook != null)
            {
                model = new BookListViewModel()
                {
                    Books = book.Items.Where(input => 
                       input.BookTitle!.Contains(searchBook) ||
                       input.Id!.ToString().Contains(searchBook) || 
                       input.BookPublisher!.Contains(searchBook) ||
                       input.Category!.CategoryName.ToString().Contains(searchBook) ||
                       input.Author.AuthorName.ToString().Contains(searchBook)).ToList(),
                };
            }
            else
            {
                model = new BookListViewModel()
                {
                    Books = book.Items.ToList(),
                };
            }
            return View(model);
        }
        [HttpGet]
        #endregion

        #region Book Create or Edit Page View
        public async Task<IActionResult> CreateOrEditBook(int id)
        {
            var model = new CreateOrEditBookViewModel();
            var category = await _categoryIAppService.GetAllBookCategory();
            var author = await _authorIAppService.GetAllAuthors();

            if (id != 0)
            {
                var book = await _bookIAppService.GetAsync(new EntityDto<int>(id));
                model = new CreateOrEditBookViewModel()
                {
                    Id = book.Id,
                    BookTitle = book.BookTitle,
                    BookPublisher = book.BookPublisher,
                    AuthorId = book.AuthorId,
                    IsBorrowed = book.IsBorrowed,
                    CategoryId = book.CategoryId,

                };
            }

            model.Authors = author;
            model.Categories = category;

            return View(model);
        }
        #endregion


    }
}
