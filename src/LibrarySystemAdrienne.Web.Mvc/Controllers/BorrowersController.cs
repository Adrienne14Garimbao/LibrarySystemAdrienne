using LibrarySystemAdrienne.Books;
using LibrarySystemAdrienne.Borrowers;
using LibrarySystemAdrienne.Borrowers.Dto;
using LibrarySystemAdrienne.Controllers;
using LibrarySystemAdrienne.Students;
using LibrarySystemAdrienne.Web.Models.Borrowers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Web.Controllers
{
    public class BorrowersController : LibrarySystemAdrienneControllerBase
    {

        private IBorrowerAppService _borrowerIAppService;
        private IBookAppService _bookIAppService;
        private IStudentAppService _studentIAppService;

        public BorrowersController(IBorrowerAppService borrowerIAppService, IBookAppService bookIAppService, IStudentAppService studentIAppService)
        {
            _borrowerIAppService = borrowerIAppService;
            _bookIAppService = bookIAppService;
            _studentIAppService = studentIAppService;
        }

        #region Borrower Index Page View
        public async Task<IActionResult> Index(string searchBorrower)
        {
            var borrowers = await _borrowerIAppService.GetAllBorrowerWithStudentAndBook(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new BorrowerListViewModel();

            if (searchBorrower != null)
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrowers.Items.Where(input => 
                    input.ReturnDate!.ToString().Contains(searchBorrower) || 
                    input.Book.BookTitle.ToString().Contains(searchBorrower) || 
                    input.Student.StudentName.ToString().Contains(searchBorrower) ||
                    input.Id!.ToString().Contains(searchBorrower) ||
                    input.ExpectedReturnDate.ToString().Contains(searchBorrower)).ToList(),
                };
            }
            else
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrowers.Items.ToList(),
                };
            }

            return View(model);
        }
        [HttpGet]
        #endregion

        #region Borrowers Create Page View
        public async Task<IActionResult> CreateBorrowers()
        {
            var model = new CreateOrEditBorrowerViewModel();
            var book = await _bookIAppService.GetAllBooksToBeBorrowed();
            var student = await _studentIAppService.GetAllBorrowersStudent();

            model.Books = book;
            model.Students = student;

            return View(model);
        }
        #endregion


        #region Borrowers Update Page View
        public async Task<IActionResult> UpdateBorrowers(int id)
        {
            var model = new CreateOrEditBorrowerViewModel();
            var book = await _bookIAppService.GetAllBooksToBeBorrowed(); 
            var student = await _studentIAppService.GetAllBorrowersStudent();

            if (id != 0)
            {
                var borrowers = await _borrowerIAppService.GetBorrowerWithBook(id);
                model = new CreateOrEditBorrowerViewModel()
                {
                    Id = borrowers.Id,
                    BorrowDate = borrowers.BorrowDate,
                    ExpectedReturnDate = borrowers.ExpectedReturnDate,
                    ReturnDate = borrowers.ReturnDate,
                    BookId = borrowers.BookId,
                    StudentId = borrowers.StudentId,
                };

                book.Add(borrowers.Book);
            }

            model.Books = book;
            model.Students = student;

            return View(model);
        }
        #endregion


    }
}
