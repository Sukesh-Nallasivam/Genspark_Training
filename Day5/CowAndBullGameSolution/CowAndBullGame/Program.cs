namespace CowAndBullGame
{
    internal class Program
    {
        static void StartGame(string LockedWord, int LengthLimit)
        {

            int count = 1;
            //bool result = false;
            while (true)
            {

                Console.WriteLine($"Enter the guess word attempt {count}");
                count++;
                string GuessWord = (Console.ReadLine() ?? String.Empty).ToLower();
                if (GuessWord.Length != LengthLimit)
                {
                    Console.WriteLine("Enter the word with Length {LengthLimit}");

                    continue;
                }
                int Cow = 0, Bull = 0;
                char[] GuessArray = GuessWord.ToCharArray();
                char[] LockedArray = LockedWord.ToCharArray();
                for (int i = 0; i < LengthLimit; i++)
                {
                    if (GuessArray[i] == LockedArray[i])
                    {
                        Cow++;
                    }
                    for (int j = 0; j < LengthLimit; j++)
                    {
                        if ((GuessArray[j] == LockedArray[i]) && i != j)
                        {
                            Bull++;
                        }
                    }

                }
                Console.WriteLine($"COW : {Cow}\t||\tBULL : {Bull}");
                if (Cow == LengthLimit)
                {
                    Console.WriteLine();
                    Console.WriteLine("***********CONGRATS**********");
                    Console.WriteLine($"You won on attempt number {count - 1}");

                    break;
                }
                else
                {
                    Console.WriteLine("Try Again");
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO COW AND BULL GAME");


            Console.Write("Enter the word length : ");
            int LengthLimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the secret word : ");
            string LockedWord = (Console.ReadLine() ?? String.Empty).ToLower();

            StartGame(LockedWord, LengthLimit);
        }
    }
}
