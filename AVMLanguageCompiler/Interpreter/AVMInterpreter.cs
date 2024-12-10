using System;

public class AVMInterpreter
{
    public void ParseAndExecute(string script)
    {
        // Split the script by lines (assuming one statement per line)
        string[] lines = script.Split('\n');

        foreach (var line in lines)
        {
            string trimmedLine = line.Trim();

            // Check if it's a print statement
            if (trimmedLine.StartsWith("print"))
            {
                // Check for a missing semicolon at the end of the line
                if (!trimmedLine.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Syntax Error: Missing semicolon at the end of the line: '{line.Trim()}'");
                }

                // If semicolon is present, proceed to execute
                // Extract the content inside the quotes, handling the case for potential extra spaces or parentheses
                string content = ExtractContentFromPrint(trimmedLine);

                // Execute the print statement
                ExecutePrintStatement(content);
            }
            else
            {
                // Handle any other statements here if needed
            }
        }
    }
    private string ExtractContentFromPrint(string line)
    {
        // Find the start and end positions of the content
        int startIndex = line.IndexOf('(') + 1;
        int endIndex = line.LastIndexOf(')');

        if (startIndex > 0 && endIndex > startIndex)
        {
            // Extract and return the content between the parentheses
            return line.Substring(startIndex, endIndex - startIndex).Trim(' ', '"');
        }

        // If no valid content is found, return an empty string or error message
        return string.Empty;
    }
    public void ExecutePrintStatement(string content)
    {
        // Simply print the content from the print statement
        Console.WriteLine(content);
    }
}
