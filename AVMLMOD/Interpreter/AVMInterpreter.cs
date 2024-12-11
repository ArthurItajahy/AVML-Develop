using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine; // For Unity/KSP-specific functionality


public class AVMInterpreter
{
    private Dictionary<string, int> variables = new Dictionary<string, int>();

    public void ParseAndExecute(string script)
    {
        string[] lines = script.Split('\n');
        foreach (var line in lines)
        {
            string trimmedLine = line.Trim();

            if (string.IsNullOrWhiteSpace(trimmedLine))
            {
                // Skip empty lines
                continue;
            }

            // Handle assignment statements
            if (trimmedLine.Contains("="))
            {
                if (!trimmedLine.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Syntax Error: Missing semicolon at the end of the line: '{trimmedLine}'");
                }
                HandleAssignment(trimmedLine);
            }
            // Handle print statements
            else if (trimmedLine.StartsWith("print"))
            {
                if (!trimmedLine.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Syntax Error: Missing semicolon at the end of the line: '{trimmedLine}'");
                }
                HandlePrint(trimmedLine);
            }
            else
            {
                throw new InvalidOperationException($"Syntax Error: Unknown statement: '{trimmedLine}'");
            }
        }
    }

    private void HandleAssignment(string line)
    {
        line = line.TrimEnd(';');
        var parts = line.Split('=');
        if (parts.Length != 2)
        {
            throw new InvalidOperationException($"Syntax Error: Invalid assignment: '{line}'");
        }

        string variableName = parts[0].Trim();
        string expression = parts[1].Trim();

        int value = EvaluateExpression(expression);
        variables[variableName] = value;
    }

    private int EvaluateExpression(string expression)
    {
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
        string content = line.Substring(6, line.Length - 8).Trim();

        // Check for string literals
        if (content.StartsWith("\"") && content.EndsWith("\""))
        {
            Console.WriteLine(content.Trim('"'));
        }
        else if (variables.ContainsKey(content))
        {
            Console.WriteLine(variables[content]);
        }
        else
        {
            throw new InvalidOperationException($"Runtime Error: Undefined variable or invalid syntax: '{content}'");
        }
    }
}
