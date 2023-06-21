using Abp.AutoMapper;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.BookCategory.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CreateBookCategoryDto
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }
    }
}
