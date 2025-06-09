using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesLinQ.Homework
{
    public class ProcessingLogger
    {
        public void OnProcessingStageCompleted(string stage, string input, string output)
        {
            Console.WriteLine($"Stage: {stage}");
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Output: {output}");
            Console.WriteLine("---");
        }
    }
}
