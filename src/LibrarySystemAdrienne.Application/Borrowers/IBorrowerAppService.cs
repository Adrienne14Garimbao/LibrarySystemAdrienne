using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Books.Dto;
using LibrarySystemAdrienne.Borrowers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Borrowers
{
    public interface IBorrowerAppService : IAsyncCrudAppService<BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>
    {
        Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithStudentAndBook(PagedResultRequestDto input);

        Task<BorrowerDto> GetBorrowerWithBook(int id);

    }
}
