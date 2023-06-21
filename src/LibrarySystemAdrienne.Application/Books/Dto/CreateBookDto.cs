using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Books.Dto
{
    [AutoMapTo(typeof(Book))]

    public class CreateBookDto 
    {
        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool IsBorrowed { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

    }
}
