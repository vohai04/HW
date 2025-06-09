using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLinQ.Homework
{
    public class ErrorHandler
    {
        public void OnErrorOccurred(string operation, string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR! Operation: {operation} - {errorMessage}");
            Console.ResetColor();
        }
    }
}
