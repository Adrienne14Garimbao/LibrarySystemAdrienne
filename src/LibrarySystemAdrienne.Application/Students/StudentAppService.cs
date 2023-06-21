using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.Entities;
using LibrarySystemAdrienne.Students.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        private readonly IRepository<Student, int> _repositoryStudent;
        public StudentAppService(IRepository<Student, int> repository) : base(repository)
        {
            _repositoryStudent = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Student> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<StudentDto>> GetAllStudentWithDepartment(PagedResultRequestDto input)
        {
            var students = await _repositoryStudent.GetAll()
                .Include(d => d.Department)
                .Select(d => ObjectMapper.Map<StudentDto>(d))
                .ToListAsync();

            return new PagedResultDto<StudentDto>(students.Count(), students);
        }

        public async Task<List<StudentDto>> GetAllBorrowersStudent()
        {
            var student = await _repositoryStudent.GetAll()
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();

            return student;

        }


    }
}
