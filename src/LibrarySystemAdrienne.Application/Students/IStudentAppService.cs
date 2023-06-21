using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemAdrienne.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        Task<PagedResultDto<StudentDto>> GetAllStudentWithDepartment(PagedResultRequestDto input);

        Task<List<StudentDto>> GetAllBorrowersStudent();
    }
}
