﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Entities
{
    public class Book : FullAuditedEntity<int>
    {
        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool IsBorrowed { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
