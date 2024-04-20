namespace Question5
{
    internal class Program
    {
        static bool IsValid(string text)
        {
            int sum=0; int current=0;
            for (int i = 0; i < text.Length; i++)
            {
                if(i%2 != 0)
                {
                    current = Convert.ToInt32(text[i]-'0')*2;
                    if(current >= 10)
                    {
                        current=current-9;
                    }
                    sum=sum+current;   
                }
                else 
                {
                    sum = sum+Convert.ToInt32(text[i]-'0');
                }
            }
            Console.WriteLine(sum); 
            return sum % 10 == 0;
        }
        static string ReversingMethod(string value) 
        {
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the card number");
            string Number = Console.ReadLine();
            string reversedString=ReversingMethod(Number);
            if (IsValid(reversedString))
            {
                Console.WriteLine("The card is valid");
            }
            else
            {
                Console.WriteLine("The card is not valid");
            }

        }
    }
}
