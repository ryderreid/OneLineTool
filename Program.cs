using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("OneLineTool v1.0Beta");
        Console.WriteLine("Copyright (c) 2023 Ryder Reid Software. All rights reserved.");
        Console.Title = "OneLineTool v1.0Beta";
        // Get the path to the user's desktop folder
        string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Specify the file name and combine it with the desktop folder path
         string baseFileName = "OneLineToolExport";

        // Initialize variables for the file path and the file number
        string filePath;
        int fileNumber = 0;

        do
        {
            // Generate the file path with an incremented number
            filePath = Path.Combine(documentsFolderPath, $"{baseFileName}_{fileNumber}.txt");
            fileNumber++;
        } while (File.Exists(filePath)); // Check if the file already exists

        bool addMoreWords = true; // Default to adding more words

        while (addMoreWords)
        {
            Console.Write("Enter words to add: ");
            string inputText = Console.ReadLine();

            // Split the input text into words
            string[] words = inputText.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                // Open the file in append mode (using FileMode.Append)
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string word in words)
                    {
                        // Append each word to the file
                        writer.WriteLine(word);
                    }
                }

                Console.WriteLine($"Words have been added to '{filePath}'");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            Console.Write("Do you want to add more words (Y/N)? ");
            string response = Console.ReadLine();

            addMoreWords = (response.Trim().ToLower() == "y");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); // Wait for a key press before exiting
    }
}