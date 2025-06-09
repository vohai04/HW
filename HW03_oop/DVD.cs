using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    public class DVD : LibraryItem, IBorrowable
    {
        // Các thuộc tính riêng của DVD
        public string Director { get; set; }
        public int Runtime { get; set; } // thời lượng (phút)
        public string AgeRating { get; set; }

        // Triển khai các thuộc tính từ interface IBorrowable
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Constructor
        public DVD(int id, string title, int publicationYear, string director/*, int runtime, string ageRating*/)
            : base(id, title, publicationYear)
        {
            Director = director;
           // Runtime = runtime;
           // AgeRating = ageRating;
        }

        // Ghi đè phương thức trừu tượng từ lớp cha
        public override void DisplayInfo()
        {
            Console.WriteLine($"DVD - ID: {Id}, Title: {Title}, Year: {PublicationYear}, Director: {Director}, Runtime: {Runtime} mins, Age Rating: {AgeRating}, Is Available : {IsAvailable}");
        }

        // Ghi đè phương thức tính phí trễ
        public override decimal CalculateLateReturnFee(int daysLate)
        {
            return daysLate * 1.00m; // Phí trễ: 1.00 mỗi ngày
        }

        // Triển khai phương thức từ interface
        public void Borrow()
        {
            if (IsAvailable)
            {
                BorrowDate = DateTime.Now;
                IsAvailable = false;
                Console.WriteLine($"DVD '{Title}' borrowed on {BorrowDate}");
            }
            else
            {
                Console.WriteLine($"DVD '{Title}' not available.");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                ReturnDate = DateTime.Now;
                IsAvailable = true;
                Console.WriteLine($"DVD '{Title}' are returned on {ReturnDate}");
            }
            else
            {
                Console.WriteLine($"DVD '{Title}' not borrowed.");
            }
        }
    }
}
