namespace Calculator
{
    internal class OperatorsParser
    {
        public static Operators ParseOperator(char op)
        {
            if (Enum.IsDefined(typeof(Operators), (int)op))
            {
                return (Operators)op;
            }
            else
            {
                throw new ArgumentException("Invalid operator", nameof(op));
            }
        }
    }
}