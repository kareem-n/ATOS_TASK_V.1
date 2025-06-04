namespace PractiseEFCore
{
    class Program
    {
        static void DrawLine()
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        static bool TryReadNumber(string label, out double number)
        {
            Console.Write(label);
            number = 0;

            string input = ReadLineWithEscape(); // detects ESC and exits
            return double.TryParse(input, out number);
        }

        static string ReadLineWithEscape()
        {
            string input = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nExiting...");
                    Environment.Exit(0);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input[..^1];
                    Console.Write("\b \b");
                }
                else
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            DrawLine();
            Console.WriteLine($"* \t SIMPLE CALCULATOR \t\t*");
            DrawLine();
            Console.ForegroundColor = ConsoleColor.White;
            ////////
            ///

            do
            {

                double num1, num2, result = 0.0;

                while (!TryReadNumber("Enter number 1 [press 'esc' to terminate] : ", out num1)) ;

                while (!TryReadNumber("Enter number 2 [press 'esc' to terminate] : ", out num2)) ;


                Console.Write("Enter Operation [+,-,*,/] : ");
                char operation = Console.ReadKey().KeyChar;
                switch (operation)
                {
                    case '+':
                        result = Calculator.Add(num1, num2);
                        break;
                    case '-':
                        result = Calculator.Subtract(num1, num2);
                        break;
                    case '*':
                        result = Calculator.Multiply(num1, num2);
                        break;
                    case '/':
                        var re = Calculator.Divide(num1, num2);
                        if (re.result != null)
                        {
                            result = (double)Calculator.Divide(num1, num2).result!;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(re.msg);
                            continue;
                        }
                        break;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{num1} {operation} {num2} = {Math.Round(result, 2)}");
                Console.ForegroundColor = ConsoleColor.White;

            }
            while (true);


        }
    }

}
