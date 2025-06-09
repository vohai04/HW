using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLinQ.Homework
{
    
    // TODO: Create subscriber classes

    public class CalculationLogger
    {
        // TODO: Implement event handlers for logging operations and errors
         public void OnOperationPerformed(string operation, double operand1, double operand2, double result)
        {
            Console.WriteLine($"Operation: {operation}, Operands: {operand1}, {operand2}, Result: {result}");
        }
         public void OnErrorOccurred(string operation, string errorMessage)
        {
            Console.WriteLine($"ERROR! Operation: {operation} - {errorMessage}");
        }
    }
}
