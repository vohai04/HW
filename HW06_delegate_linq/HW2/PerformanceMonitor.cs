using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLinQ.Homework
{
    public class PerformanceMonitor
    {
        private readonly Dictionary<string, List<double>> _processingTimes = new Dictionary<string, List<double>>();

        public void OnProcessingStageCompleted(string stage, string input, string output)
        {
            // Simulate measuring processing time (in milliseconds)
            // In a real scenario, you would use Stopwatch to measure actual processing time
            double processingTime = new Random().Next(10, 100) / 10.0; // Random time between 1-10ms

            if (!_processingTimes.ContainsKey(stage))
                _processingTimes[stage] = new List<double>();

            _processingTimes[stage].Add(processingTime);
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("\nPerformance Statistics:");
            foreach (var stage in _processingTimes)
            {
                double avgTime = stage.Value.Count > 0 ? stage.Value.Average() : 0;
                Console.WriteLine($"Stage: {stage.Key}");
                Console.WriteLine($"  Executions: {stage.Value.Count}");
                Console.WriteLine($"  Avg Time: {avgTime:F2} ms");
                Console.WriteLine($"  Total Time: {stage.Value.Sum():F2} ms");
            }
        }
    }
}
