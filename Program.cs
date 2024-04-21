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
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("You can't divide by 0.");
                    }
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

            Console.WriteLine("*--------------------*");
            Console.WriteLine("* Console Calculator *");
            Console.WriteLine("*--------------------*");

            char i = Char.MinValue;
            string input = "";

            while (!endApp)
            {
                Console.Write("\nType a desired operation: ");

                do
                {
                    i = Console.ReadKey().KeyChar;

                    if (i == '=')
                    {
                        break;
                    }
                    else if (i == 'q')
                    {
                        endApp = true;
                        break;
                    }

                    input += i;
                } while (true);

                if (i == '=')
                {
                    ProcessOperation(input);
                    input = "";
                }
                else if (endApp)
                {
                    break;
                }

                Console.WriteLine("\nPress \"Enter\" to start new operation or press \"q\" to close the app:");
            }

        }

        static void ProcessOperation(string input)
        {
            char[] operators = { '+', '-', '*', '/' };
            var opIndex = input.IndexOfAny(operators);

            if (opIndex != -1)
            {
                char op = Convert.ToChar(input.Substring(opIndex, 1));

                double num1 = Convert.ToDouble(input.Substring(0, opIndex));
                double num2 = Convert.ToDouble(input.Substring(opIndex + 1));

                double result = Calculator.DoCalc(num1, num2, op);

                Console.Write(result);
            }
            else
            {
                Console.WriteLine("No valid operator found (\"+\", \"-\", \"*\", \"/\").");
            }
        }
    }
}
