// A utility to analyze text files and provide statistics
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Read the file content
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"COntent: {content}");
                // TODO: Implement analysis functionality
                // 1. Count words
                // 2. Count characters (with and without whitespace)
                // 3. Count sentences
                // 4. Identify most common words
                // 5. Average word length

                // Example implementation for counting lines:
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");
                //1.Count words
                int CountWord = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Number of words: {CountWord}");
                //2.Count characters(with whitespace)
                int charCount = content.Length;
                Console.WriteLine($"character with whitespace: {charCount}");
                //2.Count characters (without whitespace)
                int charCountWithoutWhitespace = content.Replace(" ", "").Length;
                Console.WriteLine($"character without whitespace: {charCountWithoutWhitespace}");
                // 3. Count sentences
                int countSentences = content.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Number of sentences: {countSentences}");
                // Identify most common words
                string[] words = content.ToLower().Split(new[] { ' ', '\n', '\r', '.', ',', '!', '?','(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, int> wordCount = new Dictionary<string, int>();
                foreach(string word in words)
                {
                    if(wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount.Add(word, 1);
                    }
                }
                int maxFre = wordCount.Values.Max();
                var mostCommonWords = wordCount.Where(pair => pair.Value == maxFre)
                              .Select(pair => $"{pair.Key} ({pair.Value} times)")
                              .ToList();
                Console.WriteLine($"Most common word(s): {string.Join(", ", mostCommonWords)}");
                // Average word length
                double averageWordLength = words.Length > 0 ? words.Average(w => w.Length) : 0;
                Console.WriteLine($"Average word length: {averageWordLength:F2} characters");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }
    }
}