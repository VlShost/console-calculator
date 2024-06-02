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
            var isValidOperator = false;

            foreach (char symbol in input)
            {
                try
                {
                    Operators op = OperatorsParser.ParseOperator(symbol);
                    int opIndex = input.IndexOf(symbol);

                    if (opIndex != -1)
                    {
                        if (double.TryParse(input.Substring(0, opIndex), out double num1) &&
                        double.TryParse(input.Substring(opIndex + 1), out double num2))
                        {
                            double result = Calculator.DoCalc(num1, num2, op);
                            Console.Write(result);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid numbers format or words in input.");
                        }
                    }

                    isValidOperator = true;
                    break;
                }
                catch(ArgumentException)
                {
                } 
            }
            if (!isValidOperator)
            {
                Console.WriteLine("\nNo valid operator found (\"+\", \"-\", \"*\", \"/\").");
            }
        }
    }
}
