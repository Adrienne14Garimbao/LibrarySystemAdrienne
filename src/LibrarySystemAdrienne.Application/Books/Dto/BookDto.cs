using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemAdrienne.Authors.Dto;
using LibrarySystemAdrienne.BookCategory.Dto;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Books.Dto
{
    [AutoMapFrom(typeof(Book))]
    [AutoMapTo(typeof(Book))]

    public class BookDto : EntityDto<int>
    {
        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool IsBorrowed { get; set; }

        public int AuthorId { get; set; }

        public AuthorDto Author { get; set; }

        public int CategoryId { get; set; }

        public BookCategoryDto Category { get; set; }
    }
}
