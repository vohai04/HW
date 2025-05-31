namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton Pattern Homework - Logger System\n");

            // Test that we're working with the same instance
            Console.WriteLine("Creating first logger instance...");
            Logger logger1 = Logger.GetInstance;

            Console.WriteLine("\nCreating second logger instance...");
            Logger logger2 = Logger.GetInstance;

            Console.WriteLine($"\nAre both loggers the same instance? {ReferenceEquals(logger1, logger2)}");
            Console.WriteLine($"Total instances created: {Logger.InstanceCount} (should be 1)\n");

            // Test threading to demonstrate potential issues without proper thread safety
            ThreadingDemo.RunThreadingTest();

            // Use the services which use the logger
            UserService userService = new UserService();
            PaymentService paymentService = new PaymentService();

            // Test with valid data
            userService.RegisterUser("john_doe");
            paymentService.ProcessPayment("john_doe", 99.99m);

            // Test with invalid data
            userService.RegisterUser("");
            paymentService.ProcessPayment("jane_doe", -50);

            // Test with data that triggers a warning
            paymentService.ProcessPayment("big_spender", 5000m);

            // Display all logs
            Logger.GetInstance.DisplayLogs();

            // Clear logs
            Logger.GetInstance.ClearLogs();

            // Add a few more logs after clearing
            Logger.GetInstance.LogInfo("Application shutting down");

            // Display logs again
            Logger.GetInstance.DisplayLogs();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

