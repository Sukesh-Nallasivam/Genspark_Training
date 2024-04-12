namespace Question5
{
    internal class Program
    {
        static void Main()
        {
            string username, password;
            int attempts = 3;

            while (attempts > 0)
            {
                Console.WriteLine("Enter username:");
                username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                password = Console.ReadLine();

                if (username == "ABC" && password == "123")
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        Console.WriteLine($"Incorrect username or password. You have {attempts} attempts left.");
                    }
                    else
                    {
                        Console.WriteLine("Limit exceeded");
                    }
                }
            }
        }
    }

}
