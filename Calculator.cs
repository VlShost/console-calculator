namespace Calculator
{
    internal class Calculator
    {
        public static double DoCalc(double num1, double num2, Operators op)
        {
            double result = double.NaN;
            switch (op)
            {
                case Operators.Add:
                    result = num1 + num2;
                    break;
                case Operators.Subtract:
                    result = num1 - num2;
                    break;
                case Operators.Multiply:
                    result = num1 * num2;
                    break;
                case Operators.Divide:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("\nYou can't divide by 0.");
                        result = 0;
                    }
                    break;
                default:
                    Console.WriteLine("\nUnsupported operation.");
                    break;
            }
            return result;
        }
    }
}
