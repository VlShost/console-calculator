using System;

namespace Calculator
{
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
            foreach (char symbol in input)
            {
                foreach (Operators op in Enum.GetValues(typeof(Operators)))
                {
                    if ((char)op == symbol)
                    {
                        char operatorSymbol = (char)op;
                        int opIndex = input.IndexOf(operatorSymbol);


                        if (opIndex != -1)
                        {
                            double num1 = Convert.ToDouble(input.Substring(0, opIndex));
                            double num2 = Convert.ToDouble(input.Substring(opIndex + 1));

                            double result = Calculator.DoCalc(num1, num2, op);

                            Console.Write(result);
                        }
                        else
                        {
                            Console.WriteLine("\nNo valid operator found (\"+\", \"-\", \"*\", \"/\").");
                        }
                        break;
                    }
                }
            }
        }
    }
}
