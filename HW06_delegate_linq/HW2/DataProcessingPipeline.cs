using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesLinQ.Homework;

namespace DelegatesLinQ.Homework
{
    public class DataProcessingPipeline
    {
        public event ProcessingEventHandler ProcessingStageCompleted;

        // Individual processing methods
        public static string RemoveSpaces(string input)
        {
            string output = input.Replace(" ", "");
            return output;
        }

        public static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string AddTimestamp(string input)
        {
            return $"{DateTime.Now}: {input}";
        }

        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string EncodeBase64(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes);
        }

        public static string ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty");
            return input;
        }

        public string ProcessData(string input, DataProcessor pipeline)
        {
            if (pipeline == null)
                throw new ArgumentNullException(nameof(pipeline));

            string currentInput = input;
            try
            {
                foreach (DataProcessor processor in pipeline.GetInvocationList())
                {
                    string stageName = processor.Method.Name;
                    string output = processor(currentInput);
                    OnProcessingStageCompleted(stageName, currentInput, output);
                    currentInput = output;
                }
                return currentInput;
            }
            catch (Exception ex)
            {
                OnProcessingStageCompleted("Error", input, ex.Message);
                throw;
            }
        }

        protected virtual void OnProcessingStageCompleted(string stage, string input, string output)
        {
            ProcessingStageCompleted?.Invoke(stage, input, output);
        }
    }
}
