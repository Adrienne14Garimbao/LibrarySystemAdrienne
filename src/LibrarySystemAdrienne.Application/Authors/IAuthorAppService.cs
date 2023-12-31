﻿using Abp.Application.Services;
using LibrarySystemAdrienne.Authors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Authors
{
    public interface IAuthorAppService : IAsyncCrudAppService<AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>
    {
        Task<List<AuthorDto>> GetAllAuthors();
    }
}
