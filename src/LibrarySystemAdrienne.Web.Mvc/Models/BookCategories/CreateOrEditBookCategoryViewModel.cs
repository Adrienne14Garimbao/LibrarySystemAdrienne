using LibrarySystemAdrienne.Departments.Dto;
using LibrarySystemAdrienne.Entities;
using System.Collections.Generic;

namespace LibrarySystemAdrienne.Web.Models.BookCategories
{
    public class CreateOrEditBookCategoryViewModel
    {

        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public List<DepartmentDto> Departments { get; set; }

    }
}
