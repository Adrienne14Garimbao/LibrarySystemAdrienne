using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Books.Dto
{
    public class PagedBookResultRequestDto : PagedResultRequestDto
    {
        public string SearchBook { get; set; }
        public bool? IsActive { get; set; }
    }
}
