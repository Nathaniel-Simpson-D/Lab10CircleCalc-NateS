using System;
namespace Lab10CircleTime_NateS
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize
            int cirMade = 0;
            bool rep = Validator.GetYN("Would you like to make a Circle?");

            while (rep)
            {
                // Get Rad
                double rad = Validator.ValidateDouble("What is the Radius.");
                Circle cir = new Circle(rad);
                //Process
                string cirC = cir.CalculateFormattedCircumference();
                string cirA = cir.CalculateFormattedArea();
                //increment + print + repeat?
                cirMade++;
                PrintTable(cirC, cirA);
                rep = Validator.GetYN("Would you like to make another Circle?");
            }

            //Exit process
            Console.WriteLine($"Goodbye,we created {cirMade} Circles.");

            Console.WriteLine("Press ESC to exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Press ESC to exit...");
            }
            
        }
        public static void PrintTable(string C, string A)
        {
            string B = $"|{A}";
            Console.WriteLine("Circumference|Area");
            Console.Write($"{C,0}");
            Console.WriteLine($"{B,15}");
        }

    }
    public class Circle
    {
        #region fields
        // fields
        private double radius;

        #endregion
        #region properties
        //construtors 
        public Circle()
        {
            radius = Validator.ValidateDouble("What is the Radius?");
        }
        public Circle(double rad)
        {
            radius = rad;
        }
        //methods
        public  double CalculateCircumference()
        {
            //returns circumference as double 
            double cir = 2 * radius * System.Math.PI;
            
            return cir;
        }
        public string CalculateFormattedCircumference()
        {
            //returns circumference as string rounded to hundreths
            string formCir = FormatNumber(CalculateCircumference());
            return formCir;
        }
        public double CalculateArea()
        {
            //returns area as a double rounded to the hundreth(s)
            double cirArea = 2 * radius * radius * Math.PI;
            
            return cirArea;
        }
        public string CalculateFormattedArea()
        {
            //returns area rounded to hundreths as a string
            string formArea = FormatNumber(CalculateArea());
            return formArea;
        }
        private string FormatNumber(double x)
        {
            //returns number as a string with 2 digits past the decimal
            x = Math.Round(x, 2);
            string fX = $"{x}";
            return fX;
        }
        public double Radius()
        {
            //returns Radius as double
            return radius;
        }
        public string FormattedRadius()
        {
            //returns Radius as string
            string fRad = FormatNumber(radius);
            return fRad;
        }
        #endregion
    }
    public class Validator
    {
        //feilds
        
        #region Properties
        //Constructor
        public Validator()
        {

        }
        public Validator(string message)
        {

        }
        public static double ValidateDouble(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            bool isValid = double.TryParse(input, out double result);
            if (isValid && result > 0)
            {
                return result;
            }
            else if (isValid)
            {
                return ValidateDouble("Please enter a value GREATER THAN 0.00");
            }
            else
            {
                Console.WriteLine("(FormatException)");
                return ValidateDouble($"{input} is Not Valid!");
            }
        }
        public static bool GetYN(string message)
        {
            Console.WriteLine(message + "(Y/N)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return GetYN("Not Valid!");
            }
        }
        #endregion
    }
}