using System;
using System.IO;

public class AVMCompiler
{
    public void Compile(string filePath)
    {
        // Read the content of the file at the given path
        string script = File.ReadAllText(filePath);
        

        // Split the script into individual lines
        var lines = script.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Trim each line to remove leading and trailing whitespace
            string trimmedLine = line.Trim();

            // If the line starts with "print", and we expect content inside parentheses
            if (trimmedLine.StartsWith("print") && trimmedLine.EndsWith(")"))
            {
                // Extract the content inside the parentheses, removing "print(" and ")"
                string content = trimmedLine.Substring(6, trimmedLine.Length - 7);

                
            }
        }
    }
}
