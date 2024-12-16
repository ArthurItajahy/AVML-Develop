using System;
using System.Collections;
using System.Collections.Generic; // For advanced collection types
using System.IO;
using AVML;
using UnityEngine; // For Unity/KSP-specific functionality

class AVMLMain
{
    static void Main(string[] args)
    {
        AVMCompiler compiler = new AVMCompiler();
        AVMLInterpreter interpreter = new AVMLInterpreter();

        string filePath = "C:/Users/User/Desktop/AVMLScripts/script.avml"; // Example file path
        if (File.Exists(filePath))
        {
            string script = File.ReadAllText(filePath); // Read the contents of the .avm file


            compiler.Compile(filePath); // or pass the script directly if needed

            interpreter.ParseAndExecute(script); // or pass compiled code here
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}