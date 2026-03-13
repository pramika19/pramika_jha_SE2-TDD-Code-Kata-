using System;
using System.Collections.Generic;

namespace StringCalculatorApp
{

public class StringCalculator
{
    public int Calculate(string arg)
    {
        if (string.IsNullOrEmpty(arg))
            return 0;

        List<string> delimiters = new List<string> { ",", "\n" };

        if (arg.StartsWith("//"))
        {
            int newlineIndex = arg.IndexOf('\n');
            string delimiterPart = arg.Substring(2, newlineIndex - 2);

            if (delimiterPart.Contains("["))
            {
                int idx = 0;
                while (idx < delimiterPart.Length)
                {
                    int startBracket = delimiterPart.IndexOf('[', idx);
                    if (startBracket == -1)
                        break;
                    
                    int endBracket = delimiterPart.IndexOf(']', startBracket);
                    if (endBracket == -1)
                        break;
                    
                    string delimiter = delimiterPart.Substring(startBracket + 1, endBracket - startBracket - 1);
                    delimiters.Add(delimiter);
                    idx = endBracket + 1;
                }
            }
            else
            {
                delimiters.Add(delimiterPart);
            }

            arg = arg.Substring(newlineIndex + 1);
        }

        string[] numbers = arg.Split(delimiters.ToArray(),
                                     StringSplitOptions.None);

        int sum = 0;

        foreach (string number in numbers)
        {
            int value = int.Parse(number);

            if (value < 0)
                throw new ArgumentException("Negative numbers are not allowed");

            if (value <= 1000)
                sum += value;
        }

        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        StringCalculator calculator = new StringCalculator();

        Console.WriteLine(calculator.Calculate(""));
        Console.WriteLine(calculator.Calculate("5"));
        Console.WriteLine(calculator.Calculate("5,3"));
        Console.WriteLine(calculator.Calculate("5\n3"));
        Console.WriteLine(calculator.Calculate("1,2\n3"));
        Console.WriteLine(calculator.Calculate("1,2,3"));
        Console.WriteLine(calculator.Calculate("1\n2\n3"));
        Console.WriteLine(calculator.Calculate("//#\n2#3"));
        Console.WriteLine(calculator.Calculate("//[###]\n2###3###4"));
        Console.WriteLine(calculator.Calculate("//[*][%]\n1*2%3"));
        Console.WriteLine(calculator.Calculate("//[***][%%%]\n1***2%%%3"));

       // Console.WriteLine(calculator.Calculate("1,-2,3"));
    }
}
}
