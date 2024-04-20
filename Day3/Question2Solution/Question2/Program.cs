namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering numbers...");
            Console.WriteLine();
            Console.WriteLine("Enter negative number to exit");
            int max = 0;
            while (true) {
                int value=Convert.ToInt32(Console.ReadLine());
                if (value <0) {
                    Console.WriteLine($"The greatest number is {max}");
                    break;
                }
                if(value >max) { 
                max = value;
                }
            }
        }
    }
}