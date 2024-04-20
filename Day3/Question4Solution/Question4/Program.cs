using System;
namespace Question4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter name");
            string username = Console.ReadLine();
            try
            {
                int length = username.Length;
                Console.WriteLine("Length of the username is: " + length);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Username is null.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Username is empty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

