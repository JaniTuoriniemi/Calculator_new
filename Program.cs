using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace calculator
{
    public class Program
    {
        static void Main(string[] args)
        {                  // The program is initialised. 
            bool is_on = true;
            bool isarray = false;
            while (is_on)
            { // The lines below process the user input into relevant arrays and variables.
                Console.WriteLine("Welcome to the calculator. \r\n  Give at least two numbers separated by commas");
                string raw_numbers = Console.ReadLine();
                string[] numbers = raw_numbers.Split(',');
                double[] double_numbers = new double[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    double_numbers[i] = Convert.ToDouble(numbers[i]);
                }
                if (double_numbers.Length == 2)
                { isarray = true; }
                double a = double_numbers[0]; double b = double_numbers[1];
                Console.WriteLine("Choose your method of calculation; for addition press 1,for subtraction press 2 , for multiplication press 3,for division press 4\r\n Only addition and subtraction is possible for more than two numbers.");
                bool control = double.TryParse(Console.ReadLine(), out double ansver);// User chooses the type of calculation. 
                if (control) // If user entered an allowed number, the chosen calculation is performed below. 
                {
                    switch (ansver)
                    {
                        case 0:
                            is_on = false;
                            Console.WriteLine("Closes the program");// The program shuts down by user choice.
                            break;
                        case 1:
                            if (isarray)
                            {
                                double sum = Calculator.Addition(double_numbers);// If several numbers were entered, the sum is calculated over the whole array where they are stored.
                                Console.WriteLine($"The sum is {sum}.");
                            }
                            else// if only two numbers were provided, the overloaded method for two parameters is used instead.
                            {
                                double sum = Calculator.Addition(a, b);
                                Console.WriteLine($"The sum is {sum}.");
                            }
                            break;
                        case 2:
                            if (isarray) // Subtraction also exists as separate overloaded functions for arrays and the case for two numbers.
                            {
                                double diff = Calculator.Subtraction(double_numbers);
                                Console.WriteLine($"The sum is {diff}.");
                            }
                            else
                            {
                                double diff = Calculator.Subtraction(a, b);
                                Console.WriteLine($"The difference is {diff}.");
                            }
                            break;
                        case 3:
                            double product = Calculator.Multiplication(a, b);
                            Console.WriteLine($"The product is {product}.");
                            break;
                        case 4:// The user is warned if he tries division by zero.
                            try
                            {
                                double quotient = Calculator.Division(a, b);// The program tries to perform divison.
                                Console.WriteLine($"The quotient is: {quotient}");
                            }
                            catch (DivideByZeroException ex)// If division by zero is tried the message in the thrown exception is displayed.
                            { Console.WriteLine(ex.ToString()); }
                            break;
                        // Error handling.
                        default:
                            Console.WriteLine("Ange giltig nummer");
                            break;
                    }
                }

            }
        }
        public class Calculator // Contains the calculation methods.
        {
            public static double Addition(double a, double b)
            {
                return a + b;// Addition for two provided numbers as arguments.
            }
            public static double Addition(double[] a)// Overloaded funtion for any number of addends stored in an array.
            {
                double sum = 0;// Loop summs the elements in array.
                for (int i = 0; i < a.Length; i++)
                { sum = sum + a[i]; }
                return sum;
            }
            public static double Subtraction(double a, double b) //Two overloaded functions for substraction in a way analogous to addition.
            { return a - b; }
            public static double Subtraction(double[] a)
            {
                double diff = a[0];// Loop substracts the remaining array elements from the first one.
                for (int i = 1; i < a.Length; i++)
                { diff = diff - a[i]; }
                return diff;
            }
            public static double Multiplication(double a, double b)
            { return a * b; }

            public static double Division(double a, double b)
            {

                if (b == 0)
                {//If division by zero is tried the program throws an exception.
                    Exception ex = new DivideByZeroException("Division by zero not allowed!");
                    throw ex;
                }
                {
                    return a / b;
                }
            }
        }
    }
}


