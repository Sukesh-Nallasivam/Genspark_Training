namespace ExcelSheetCoulumnTitle
{
    internal class Program
    {
           public async Task ConvertToTitle(int columnNumber)
            {
                int num = columnNumber;
                int div, rem;
                string result = "";
                
                while (num > 0)
                {
                    num--;
                    div = (num / 26);
                    rem = (num % 26);
                    int temp = 65 + rem;
                    result = ((char)temp).ToString() + result;
                    num = div;

                }
                Console.WriteLine(columnNumber);
                await Task.Delay(10);
                Console.WriteLine(result);
            }
        static async Task Main(string[] args)
        {
            Program program = new Program();
            Random rnd = new Random();
            await program.ConvertToTitle(rnd.Next());
        }
    }
}
