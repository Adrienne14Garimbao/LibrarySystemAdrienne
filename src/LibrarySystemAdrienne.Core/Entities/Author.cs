using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Entities
{
    public class Author : FullAuditedEntity<int>
    {
        public string AuthorName { get; set; }

    }
}
