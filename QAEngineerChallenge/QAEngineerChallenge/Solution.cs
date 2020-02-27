using System;
using System.IO;
using System.Collections.Generic;

namespace QAEngineerChallenge
{
    class Solution
    {
        static void Main()
        {
            string[] files = { "1.txt", "2.txt", "3.txt", "4.txt", "5.txt" };
            try
            {
                // Looping each file
                foreach (string file in files)
                {
                    // Creating dictionary
                    var dictionary = new Dictionary<int, int>();
                    // Opening stream to read the text file
                    using (StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"src\", file)))
                    {
                        string text;
                        // Reading each line of the text file
                        while ((text = sr.ReadLine()) != null)
                        {
                            // Parsing the integers
                            int num = int.Parse(text);
                            if (dictionary.ContainsKey(num))
                            {
                                dictionary[num] += 1;
                            }
                            else
                            {
                                dictionary.Add(num, 1);
                            }
                        }
                    }

                    int index = 0;
                    // Checking which number has the smallest frequency
                    foreach (KeyValuePair<int, int> kvp in dictionary)
                    {
                        // Checking if current value is smaller then the stored value
                        if (kvp.Value < dictionary[index] ||
                            kvp.Value == dictionary[index] &&
                            kvp.Key < index)
                        {
                            index = kvp.Key;
                        }
                    }
                    Console.WriteLine("File: " + file + ", Number: " + index + ", Repeated: " + dictionary[index]);
                }
            }
            catch (IOException e)
            {
                // Display error message if file could not be read
                Console.WriteLine("File could not be read.");
                Console.WriteLine(e.Message);
            }

            // Application exits on user input
            Console.ReadLine();
        }
    }
}
