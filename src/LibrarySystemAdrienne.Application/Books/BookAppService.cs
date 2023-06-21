using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.Books.Dto;
using LibrarySystemAdrienne.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Books
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        private readonly IRepository<Book, int> _repositoryBook;

        public BookAppService(IRepository<Book, int> repository) : base(repository)
        {
            _repositoryBook = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<BookDto> CreateAsync(CreateBookDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookDto> UpdateAsync(BookDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Book> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<BookDto>> GetAllBookWithCategoryAndAuthor (PagedResultRequestDto input)
        {
            var book = await _repositoryBook.GetAll()
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Select(b => ObjectMapper.Map<BookDto>(b))
                .ToListAsync();

            return new PagedResultDto<BookDto>(book.Count(), book);
        }
        public async Task<List<BookDto>> GetAllBooksToBeBorrowed()
        {
            var borrowers = await _repositoryBook.GetAll()
                .Where(h => h.IsBorrowed == false)
                .Select(b => ObjectMapper.Map<BookDto>(b))
                .ToListAsync();

            return borrowers;

        }

        public async Task<BookDto> UpdateStatusOfBooks(EntityDto<int> input)
        {
            var book = await GetAsync(input);

            if (book.IsBorrowed == true)
            {
                book.IsBorrowed = false;
            }
            else
            {
                book.IsBorrowed = true;
            }
            var updateBook = await UpdateAsync(book);

            return updateBook;
        }


    }
}
