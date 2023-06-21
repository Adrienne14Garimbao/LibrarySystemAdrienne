using Abp.Domain.Entities.Auditing; /*  FullAuditedEntity */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Entities
{
    public class Department : FullAuditedEntity<int>
    {
        /* Column Name */
        public string DepartmentName { get; set; }
    }
}
