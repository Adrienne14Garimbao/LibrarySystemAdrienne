using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.BookCategory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.BookCategory
{
    public interface IBookCategoryAppService : IAsyncCrudAppService<BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>
    {
        Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoryWithDepartment(PagedResultRequestDto input);
        Task<List<BookCategoryDto>> GetAllBookCategory();

    }
}
