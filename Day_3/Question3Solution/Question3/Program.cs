namespace Question3
{
    class program
    {
        static void Average(int Sum,int Count)
        {
            try {
                Console.WriteLine(Sum/Count);
            } 
            catch (Exception) { 
            Console.WriteLine("just");
            }
        }
        static void InputMethod()
        {
            int Sum = 0;
            int count = 0;
            while (true)
            {
                int Number=Convert.ToInt32(Console.ReadLine());
                if(Number < 0)
                {
                    Average(Sum, count);
                    break;
                }
                if (Number%7==0) { 
                    Sum=Sum+Number;
                    count++;
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers");
            InputMethod();
        }
    }
}