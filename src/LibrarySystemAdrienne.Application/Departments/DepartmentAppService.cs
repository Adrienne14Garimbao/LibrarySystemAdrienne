using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Departments
{
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentAppService
    {
        private IRepository<Department, int> _repositoryDepartment;

        public DepartmentAppService(IRepository<Department, int> repository) : base(repository)
        {
            _repositoryDepartment = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<DepartmentDto>> GetAllAsync(PagedDepartmentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<DepartmentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<DepartmentDto> UpdateAsync(DepartmentDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Department> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var query = await _repositoryDepartment.GetAll()
                .Select(d => ObjectMapper.Map<DepartmentDto>(d))
                .ToListAsync();

            return query;
        }


    }
}
