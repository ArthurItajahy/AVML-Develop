using System;
using System.Collections.Generic;

public class AVMInterpreter
{
    // Dictionary to store variables
    private Dictionary<string, int> variables = new Dictionary<string, int>();

    public void ParseAndExecute(string script)
    {
        // Split the script by lines (assuming one statement per line)
        string[] lines = script.Split('\n');

        foreach (var line in lines)
        {
            string trimmedLine = line.Trim();

            // Check for assignment statements (e.g., x = 2 + 2;)
            if (trimmedLine.Contains("="))
            {
                // Process assignment
                if (!trimmedLine.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Syntax Error: Missing semicolon at the end of the line: '{trimmedLine}'");
                }

                HandleAssignment(trimmedLine);
            }
            else if (trimmedLine.StartsWith("print"))
            {
                // Check for a missing semicolon at the end of the line
                if (!trimmedLine.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Syntax Error: Missing semicolon at the end of the line: '{trimmedLine}'");
                }

                // Extract and print the variable or literal
                HandlePrint(trimmedLine);
            }
            else if (!string.IsNullOrWhiteSpace(trimmedLine))
            {
                throw new InvalidOperationException($"Syntax Error: Unknown statement: '{trimmedLine}'");
            }
        }
    }

    private void HandleAssignment(string line)
    {
        // Remove the semicolon
        line = line.TrimEnd(';');

        // Split the line into variable and expression
        var parts = line.Split('=');
        if (parts.Length != 2)
        {
            throw new InvalidOperationException($"Syntax Error: Invalid assignment: '{line}'");
        }

        string variableName = parts[0].Trim();
        string expression = parts[1].Trim();

        // Evaluate the expression
        int value = EvaluateExpression(expression);

        // Store the variable
        variables[variableName] = value;
    }

    private int EvaluateExpression(string expression)
    {
        // Basic arithmetic evaluation (supports only + for simplicity)
        var tokens = expression.Split('+');
        int result = 0;
        foreach (var token in tokens)
        {
            string trimmedToken = token.Trim();
            if (int.TryParse(trimmedToken, out int number))
            {
                result += number;
            }
            else if (variables.ContainsKey(trimmedToken))
            {
                result += variables[trimmedToken];
            }
            else
            {
                throw new InvalidOperationException($"Syntax Error: Undefined variable or invalid number: '{trimmedToken}'");
            }
        }
        return result;
    }

    private void HandlePrint(string line)
    {
        // Remove "print(" and ");"
        string content = line.Substring(6, line.Length - 8).Trim();

        // Check if it's a variable or a literal
        if (variables.ContainsKey(content))
        {
            Console.WriteLine(variables[content]);
        }
        else
        {
            throw new InvalidOperationException($"Runtime Error: Undefined variable '{content}'");
        }
    }
}
