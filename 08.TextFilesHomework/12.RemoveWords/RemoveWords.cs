using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
    class RemoveWords
    {
        //removes only whole words, not substrings
        static void Main()
        {
            try
            {
                //INPUT
                Console.WriteLine("Processing text.txt using words.txt...");
                string wordsListPath = "../../words.txt";
                StreamReader reader = new StreamReader(wordsListPath);
                string wordsString = reader.ReadToEnd();
                reader.Close();

                if (wordsString==string.Empty)
                {
                    throw new ArgumentException();
                }

                var words = new List<string>(wordsString.Split(','));

                string textPath = "../../text.txt";
                foreach (string word in words)
                {
                    File.WriteAllText(textPath, Regex.Replace(File.ReadAllText(textPath),"\\b" + word + "\\b", string.Empty));
                }

                var lines = File.ReadAllLines(textPath)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => Regex.Replace(x, @"\s+", " "))
                    .Select(x => x.Trim());

                File.WriteAllLines(textPath, lines);
                Console.WriteLine("Completed.");
            }
            catch 
            {
                Console.WriteLine("\nMISSING_FILES_OR_EMPTY_FILES\n");
                return;
            }
        }
    }