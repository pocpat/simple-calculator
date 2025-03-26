using System;
using System.Text.RegularExpressions;

namespace Calc3
{
    public class CalculationLogics
    {
        public string validS;
        public double num1;
        public double num2;
        public char[] operators = { '+', '-', '/', '*' };
        public char op;
        public double result;
        public bool inputValidation(string s)
        {
            string pattern = @"^[\d.+\-*/=]+$"; // Define the regex pattern
            if (Regex.IsMatch(s, pattern) && s.Length >= 4)
            {
                validS = s;

                return true;
            }
            else if (s.Length < 4)
            {
                Console.WriteLine("Enter at least 4 characters.");
                return false;
            }

            else
            {
                Console.WriteLine("Enter only numbers, operators, and '='.");
                return false;
            }
        }
        public void separation()
        {
            //remove '=' from the input
            validS = validS.TrimEnd('=');
            // find index of the operator
            int opIndex = -1;
            for (int i = 0; i < validS.Length; i++)
            {
                if (Array.IndexOf(operators, validS[i]) != -1) //  check for operator
                {
                    op = validS[i];
                    opIndex = i;
                    break;
                }

            }

            // find num1 and num2

            if (opIndex != -1)
            {
                string num1String = validS.Substring(0, opIndex);
                string num2String = validS.Substring(opIndex + 1);

                if (double.TryParse(num1String, out num1) && double.TryParse(num2String, out num2))
                {
                    // Successfully parsed num1 and num2
                }
                else
                {
                    // Handle parsing error (e.g., log an error, throw an exception)
                    Console.WriteLine("Error parsing numbers.");
                }
            }
            else
            {
                // Handle case where no operator is found
                Console.WriteLine("No operator found.");
            }

        }

        public double calculations()
        {

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Error: Division by zero.");
                        return 0;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    return 0;

            }
           // Console.WriteLine($"Result: {result}");
            return result;
        }




        static void Main(string[] args)
        {
            Console.Write("Enter expression: ");
            string input = "";
            char keyChar;


            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(false); // Read key without displaying
                keyChar = keyInfo.KeyChar;

                if (char.IsDigit(keyChar) || "+-*/=".Contains(keyChar))
                {
                 //   Console.Write(keyChar); // Display only valid characters
                    input += keyChar;
                }

            } while (keyChar != '=');

           // Console.WriteLine(); // Move to next line after input is complete

            // Validate and process the input
            CalculationLogics cl = new CalculationLogics();
            if (cl.inputValidation(input))
            {
                cl.separation();
                double res = cl.calculations();

                // Append the result to the input and display
               Console.WriteLine($"{res}");
            }
        }
    }
}
    