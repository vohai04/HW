using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    using System;

    public interface IBorrowable
    {
        // Properties
        DateTime? BorrowDate { get; set; }
        DateTime? ReturnDate { get; set; }
        bool IsAvailable { get; set; }

        // Methods
        void Borrow();
        void Return();
    }

}
