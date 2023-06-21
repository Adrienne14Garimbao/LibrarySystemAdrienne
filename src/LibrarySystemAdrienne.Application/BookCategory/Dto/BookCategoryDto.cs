using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.BookCategory.Dto
{
    [AutoMapFrom(typeof(Category))]
    [AutoMapTo(typeof(Category))]
    public class BookCategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
