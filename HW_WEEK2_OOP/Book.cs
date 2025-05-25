using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    public class Book : LibraryItem, IBorrowable
    {
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }

        // Thuộc tính interface
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book(int id, string title, int publicationYear, string author/*, int pages, string genre*/)
            : base(id, title, publicationYear)
        {
            Author = author;
           // Pages = pages;
           // Genre = genre;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Pages: {Pages}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Is Available: {IsAvailable}");
        }
        public override decimal CalculateLateReturnFee(int daysLate)
        {
            return daysLate *0.75m;
        }
        
        public void Borrow()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"Error: Book '{Title}' not available");
                return; // Thoát khỏi method, không thực hiện các lệnh bên dưới
            }

            IsAvailable = false;
            BorrowDate = DateTime.Now;
            Console.WriteLine($"Book '{Title}' borrowed on {BorrowDate.Value.ToShortDateString()}.");
        }
        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                ReturnDate = DateTime.Now;
                Console.WriteLine($"Book '{Title}' returned on {ReturnDate.Value.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine($"Book '{Title}' was not borrowed.");
            }
        }
    }
}
