using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Authors.Dto
{
    [AutoMapFrom(typeof(AuthorDto))]
    [AutoMapTo(typeof(Author))]
    public class CreateAuthorDto
    {
        public string AuthorName { get; set; }
    }
}
