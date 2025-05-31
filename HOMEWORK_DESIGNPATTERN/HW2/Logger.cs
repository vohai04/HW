using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Logger
    {
         
        // Private static instance of the Logger class
        private static Logger _instance;

        // Private lock object for thread safety
        private static readonly object _lock = new object();

        // Counter to track instance creation attempts
        private static int _instanceCount = 0;

        // Collection to hold log messages
        private List<string> _logMessages;

        // Private constructor to prevent instantiation from outside
        private Logger()
        {
            _logMessages = new List<string>();
            _instanceCount++;
            Console.WriteLine($"Logger instance created. Instance count: {_instanceCount}");
        }

        // Public static method to get the single instance
        public static Logger GetInstance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_lock)
                    {
                        // Double-check if _instance is still null after acquiring the lock
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                // TODO: Implement the GetInstance property using double-check locking pattern
                // 1. First check if _instance is null without locking (for performance)
                // 2. If it's null, acquire the lock using the _lock object
                // 3. Double-check if _instance is still null after acquiring the lock
                // 4. If still null, create a new instance
                // 5. Return the instance
                return _instance;
                // return null; // Replace this with your implementation
            }
        }

        // Alternative implementation - Option #1 (eager initialization)
        // Students can uncomment and implement this approach as an alternative
        // Comment: This approach creates the instance when the class is loaded
        /*
        // Private static instance initialized immediately (eager)
        private static readonly Logger _eagerInstance = new Logger();
        
        // Simple property returning the already-created instance
        public static Logger GetEagerInstance
        {
            get
            {
                return _eagerInstance;
            }
        }
        */

        // Alternative implementation - Option #2 (simple thread-safe using lock only)
        // Students can uncomment and implement this approach as an alternative
        // Comment: This approach is thread-safe but less efficient
        /*
        public static Logger GetSimpleThreadSafeInstance
        {
            get
            {
                // TODO: Implement simple thread-safe singleton using only lock
                // 1. Acquire the lock
                // 2. Check if _instance is null
                // 3. Create new instance if null
                // 4. Return the instance
                
                return null; // Replace with implementation
            }
        }
        */

        // Public property to access instance count (for demonstration)
        public static int InstanceCount
        {
            get { return _instanceCount; }
        }

        // Method to log an information message
        public void LogInfo(string message)
        {
            // TODO: Implement LogInfo method
            // 1. Format the log entry with current timestamp, log level (INFO), and the message
            //    Format example: "[2023-05-20 14:30:45] [INFO] User logged in"
            // 2. Add the formatted entry to _logMessages list
            // 3. Print the log entry to the console
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] {message}";
            _logMessages.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        // Method to log an error message
        public void LogError(string message)
        {
            // TODO: Implement LogError method
            // Similar to LogInfo but with ERROR level
            // Format example: "[2023-05-20 14:30:45] [ERROR] Database connection failed"
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERROR] {message}";
            _logMessages.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        // Method to log a warning message
        public void LogWarning(string message)
        {
            // TODO: Implement LogWarning method
            // Similar to LogInfo but with WARNING level
            // Format example: "[2023-05-20 14:30:45] [WARNING] Disk space low"
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [WARNING] {message}";
            _logMessages.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        // Method to display all log entries
        public void DisplayLogs()
        {
            Console.WriteLine("\n----- LOG ENTRIES -----");
            if (_logMessages.Count == 0)
            {
                Console.WriteLine("No log entries found.");
            }
            else
            {
                foreach (var log in _logMessages)
                {
                    Console.WriteLine(log);
                }
            }

                // TODO: Implement DisplayLogs method
                // 1. Check if there are any logs (_logMessages.Count > 0)
                // 2. If no logs, print a message saying "No log entries found."
                // 3. Otherwise, iterate through _logMessages and print each entry

                Console.WriteLine("----- END OF LOGS -----\n");
        }

        // Method to clear all logs
        public void ClearLogs()
        {
            // TODO: Implement ClearLogs method
            // 1. Clear the _logMessages list (_logMessages.Clear())
            // 2. Print a message indicating that logs have been cleared
            _logMessages.Clear();
            Console.WriteLine("All log entries have been cleared.");
        }
    }
}
