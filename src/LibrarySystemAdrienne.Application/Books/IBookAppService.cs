using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        Task<PagedResultDto<BookDto>> GetAllBookWithCategoryAndAuthor(PagedResultRequestDto input);

        Task<List<BookDto>> GetAllBooksToBeBorrowed();

        Task<BookDto> UpdateStatusOfBooks(EntityDto<int> input);

    }
}
