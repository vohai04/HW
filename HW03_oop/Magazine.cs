using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    public class Magazine : LibraryItem
    {
        // Các thuộc tính riêng của tạp chí
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        // Constructor
        public Magazine(int id, string title, int publicationYear, int issueNumber/*, string publisher*/)
            : base(id, title, publicationYear)
        {
            IssueNumber = issueNumber;
            //Publisher = publisher;
        }

        // Ghi đè phương thức trừu tượng từ lớp LibraryItem
        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine - ID: {Id}, Title: {Title}, Year: {PublicationYear}, Issue: {IssueNumber}, Publisher: {Publisher}");
        }
    }
}
