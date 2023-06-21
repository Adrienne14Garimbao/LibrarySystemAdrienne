using LibrarySystemAdrienne.Authors.Dto;
using LibrarySystemAdrienne.BookCategory.Dto;
using LibrarySystemAdrienne.Entities;
using System.Collections.Generic;

namespace LibrarySystemAdrienne.Web.Models.Books
{
    public class CreateOrEditBookViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool IsBorrowed { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public List<AuthorDto> Authors { get; set; }

        public List<BookCategoryDto> Categories { get; set; }


    }
}
