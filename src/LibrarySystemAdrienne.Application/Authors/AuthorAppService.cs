using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemAdrienne.Authors.Dto;
using LibrarySystemAdrienne.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Authors
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>, IAuthorAppService
    {
        private readonly IRepository<Author, int> _repositoryAuthor;

        public AuthorAppService(IRepository<Author, int> repository) : base(repository)
        {
            _repositoryAuthor = repository;
        }

        #region Default Generated Overrride for CRUD Service 
        public override Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAuthorResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<AuthorDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<AuthorDto> UpdateAsync(AuthorDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Author> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            var author = await _repositoryAuthor.GetAll()
                .Select(a => ObjectMapper.Map<AuthorDto>(a))
                .ToListAsync();

            return author;
        }

    }
}
