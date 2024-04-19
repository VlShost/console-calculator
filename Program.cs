using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoCalc(double num1, double num2, char op)
        {
            double result = double.NaN;
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
                    if (num2 == 0)
                    {
                        Console.WriteLine("You can't divide by 0.");
                        return 0;
                    }
                        result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Unsupported operation.");
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator");
            Console.WriteLine("------------------");

            while (!endApp)
            {
                Console.Write("Type a desired operation: ");
                string input = Console.ReadLine();

                char[] operators = { '+', '-', '*', '/' };
                char op = ' ';
                double num1;
                double num2;
                double result = 0;

                var opIndex = input.IndexOfAny(operators);
                if (opIndex != -1)
                {
                    op = Convert.ToChar(input.Substring(opIndex, 1));

                    num1 = Convert.ToDouble(input.Substring(0, opIndex));
                    num2 = Convert.ToDouble(input.Substring(opIndex + 1));

                    result = Calculator.DoCalc(num1, num2, op);

                    Console.WriteLine($"Result: {input} = {result}\n");
                    Console.WriteLine("Press \"Enter\" to start new operation or type \"q\" to close the app:");
                }
                else
                {
                    Console.WriteLine("No valid operator found (\"+\", \"-\", \"*\", \"/\").\n");
                    Console.WriteLine("Press \"Enter\" to start new operation or type \"q\" to close the app:");
                }

                if (Console.ReadLine() == "q")
                {
                    endApp = true;
                }
            }
            return;

        }
    }
}
