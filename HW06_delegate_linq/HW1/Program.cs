using System;

namespace DelegatesLinQ.Homework
{
    // Event delegates for different operations
    public delegate void CalculationEventHandler(string operation, double operand1, double operand2, double result);
    public delegate void ErrorEventHandler(string operation, string errorMessage);

    /// <summary>
    /// Homework 1: Event Calculator
    /// Create a calculator class with events for each operation.
    /// 
    /// Requirements:
    /// 1. Create events for each mathematical operation (Add, Subtract, Multiply, Divide)
    /// 2. Create events for errors (like division by zero)
    /// 3. Create subscriber classes that handle these events:
    ///    - Logger: Logs all operations to console
    ///    - Auditor: Keeps track of operation count
    ///    - ErrorHandler: Handles and displays errors
    /// 4. Demonstrate all operations and error handling
    /// 
    /// Techniques used: Similar to 6_5_EventApp
    /// - Event declaration and raising
    /// - Multiple subscribers
    /// - Event handler methods
    /// </summary>
    public class HW1_EventCalculator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== HOMEWORK 1: EVENT CALCULATOR ===");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Implement the EventCalculator class with events for each operation");
            Console.WriteLine("2. Implement subscriber classes: CalculationLogger, CalculationAuditor, ErrorHandler");
            Console.WriteLine("3. Subscribe to events and test all operations including error cases");
            Console.WriteLine();

            // TODO: You should implement the following:
            
            EventCalculator calculator = new EventCalculator();
            CalculationLogger logger = new CalculationLogger();
            CalculationAuditor auditor = new CalculationAuditor();
            ErrorHandler errorHandler = new ErrorHandler();

            // Subscribe to events
            calculator.OperationPerformed += logger.OnOperationPerformed;
            calculator.OperationPerformed += auditor.OnOperationPerformed;
            calculator.ErrorOccurred += logger.OnErrorOccurred;
            calculator.ErrorOccurred += errorHandler.OnErrorOccurred;

            // Test operations
            calculator.Add(10, 5);
            calculator.Subtract(10, 3);
            calculator.Multiply(4, 7);
            calculator.Divide(15, 3);
            calculator.Divide(10, 0); // Should trigger error

            // Display statistics
            auditor.DisplayStatistics();
            

            Console.ReadKey();
        }
    }
}