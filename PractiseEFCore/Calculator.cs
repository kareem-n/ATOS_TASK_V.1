namespace PractiseEFCore
{
    internal static class Calculator
    {
        public static double Add(double a, double b)
        {
            return (dynamic)a + (dynamic)b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static (double? result, string? msg) Divide(double a, double b)
        {
            if (b == 0)
                return (null, "Can not Divide by Zero");

            return (a / b, null);
        }
    }
}
