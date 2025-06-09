using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLinQ.Homework
{
    public class CalculationAuditor
    {
        private int _operationCount = 0;
        private readonly Dictionary<string, int> _operationStats = new();

        public void OnOperationPerformed(string operation, double operand1, double operand2, double result)
        {
            _operationCount++;
            _operationStats[operation] = _operationStats.GetValueOrDefault(operation, 0) + 1;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("\nOperation Statistics:");
            Console.WriteLine($"Total operations performed: {_operationCount}");
            foreach (var stat in _operationStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value} times");
            }
        }
    }
}
