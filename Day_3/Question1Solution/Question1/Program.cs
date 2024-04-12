namespace Question1
{
    class Program
    {
        static double Add(double FirstNumber, double SecondNumber)
        {
            Console.Write($"Addition of {FirstNumber} and {SecondNumber} is : ");
            return FirstNumber + SecondNumber;
        }
        static double Product(double FirstNumber, double SecondNumber)
        {
            Console.Write($"Product of {FirstNumber} and {SecondNumber} is : ");
            return FirstNumber * SecondNumber;
        }
        static void Divide(double FirstNumber, double SecondNumber)
        {
            try
            {
                Console.Write($"Division of {FirstNumber} with {SecondNumber} is : ");
                Console.WriteLine( FirstNumber / SecondNumber);
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Enter non zero denominator");
            }

            
        }
        static double Subtract(double FirstNumber, double SecondNumber)
        {
            Console.Write($"Subraction of {SecondNumber} from {FirstNumber} is : ");
            return SecondNumber-FirstNumber;
        }
        static double Remainder(double FirstNumber, double SecondNumber)
        {
            Console.Write($"Remainder of {FirstNumber} with {SecondNumber} is : ");
            return FirstNumber % SecondNumber;
        }
        static void Calculation(double FirstNumber,double SecondNumber)
        {
            Console.WriteLine(Add(FirstNumber, SecondNumber));
            Console.WriteLine();
            Console.WriteLine(Product( FirstNumber, SecondNumber ));
            Console.WriteLine();
            Divide( FirstNumber, SecondNumber );
            Console.WriteLine();
            Console.WriteLine(Subtract( FirstNumber, SecondNumber ));
            Console.WriteLine();
            Console.WriteLine(Remainder(FirstNumber, SecondNumber));
        }
        static void Main(String[] args)
        {
            double FirstNumber=Convert.ToDouble(Console.ReadLine());
            double SecondNumber= Convert.ToDouble(Console.ReadLine());
            Calculation(FirstNumber,SecondNumber);
        }

    }
}