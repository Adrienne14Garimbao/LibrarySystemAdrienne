using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Entities
{
    public class Category : FullAuditedEntity<int>
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
