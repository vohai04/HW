using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    public record BorrowRecord(
    int ItemId,
    string Title,
    DateTime BorrowDate,
    DateTime? ReturnDate,
    string BorrowerName
        )
    {
        public string LibraryLocation { get; init; }
    }
}

