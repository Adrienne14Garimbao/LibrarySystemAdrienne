﻿using Abp.AutoMapper;
using LibrarySystemAdrienne.Books.Dto;
using LibrarySystemAdrienne.Entities;
using LibrarySystemAdrienne.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdrienne.Borrowers.Dto
{
    [AutoMapTo(typeof(Borrower))]
    public class CreateBorrowerDto
    {
        public DateTime BorrowDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? BookId { get; set; }

        public int? StudentId { get; set; }

    }
}
