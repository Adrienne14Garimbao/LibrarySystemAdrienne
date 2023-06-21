using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.Books;
using LibrarySystemAdrienne.Books.Dto;
using LibrarySystemAdrienne.Borrowers.Dto;
using LibrarySystemAdrienne.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Borrowers
{

    public class BorrowerAppService : AsyncCrudAppService<Borrower, BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>, IBorrowerAppService
    {
        private readonly IRepository<Borrower, int> _repositoryBorrower;
        public readonly IBookAppService _bookIAppService;

        public BorrowerAppService(IRepository<Borrower, int> repository) : base(repository)
        {
            _repositoryBorrower = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedBorrowerResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BorrowerDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BorrowerDto> UpdateAsync(BorrowerDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Borrower> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithStudentAndBook(PagedResultRequestDto input)
        {
            var borrowers = await _repositoryBorrower.GetAll()
                .Include(l => l.Book)
                .Include(l => l.Student)
                .Select(l => ObjectMapper.Map<BorrowerDto>(l))
                .ToListAsync();


            return new PagedResultDto<BorrowerDto>(borrowers.Count(), borrowers);
        }

        public async Task<BorrowerDto> GetBorrowerWithBook(int id)
        {
            var borrower = await _repositoryBorrower.GetAll()
                .Include(item => item.Book)
                .Where(item => item.Id == id)
                .Select(item => ObjectMapper.Map<BorrowerDto>(item))
                .FirstOrDefaultAsync();

            return borrower;

        }


    }
}
