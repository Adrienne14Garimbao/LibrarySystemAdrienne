using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.BookCategory.Dto;
using LibrarySystemAdrienne.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.BookCategory
{
    public class BookCategoryAppService : AsyncCrudAppService<Category, BookCategoryDto, int, PagedBookCategoryResultRequestDto, CreateBookCategoryDto, BookCategoryDto>, IBookCategoryAppService
    {
        private readonly IRepository<Category, int> _repositoryCategory;

        public BookCategoryAppService(IRepository<Category, int> repository) : base(repository)
        {
            _repositoryCategory = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookCategoryDto>> GetAllAsync(PagedBookCategoryResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookCategoryDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookCategoryDto> UpdateAsync(BookCategoryDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Category> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<BookCategoryDto>> GetAllBookCategoryWithDepartment(PagedResultRequestDto input)
        {
            var bookCategory = await _repositoryCategory.GetAll()
                .Include(c => c.Department)
                .Select(c => ObjectMapper.Map<BookCategoryDto>(c))
                .ToListAsync();


            return new PagedResultDto<BookCategoryDto>(bookCategory.Count(), bookCategory);
        }
        public async Task<List<BookCategoryDto>> GetAllBookCategory()
        {
            var book = await _repositoryCategory.GetAll()
                .Select(c => ObjectMapper.Map<BookCategoryDto>(c))
                .ToListAsync();

            return book;
        }


    }
}
