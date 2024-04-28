using ShoppingBLL;
namespace ShoppingPlatform
{
    internal class Program
    {
        //Program program = new Program();
        static void ChoiceSelection()
        {
            int choice;
            do
            {
                Console.WriteLine("Select choice....");
                Console.WriteLine("1.Product Service");

                Console.WriteLine("0.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank You Visit Again");
                        break;
                    case 1:
                        MethodForProduct();
                        break;
                    default:
                        Console.WriteLine("Ooops!!! Wrong Selection.  Please Select Opton as follows");
                        break;
                }
            } while (choice > 0);
        }
        static int GetResultFromServer()
        {
            return new Random().Next();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome AllKart:>)");
            int Num= GetResultFromServer();
            //Console.WriteLine($"This is random { Num}");
            ChoiceSelection();
        }
        static void MethodForProduct()
        {
            MethodForProduct product = new();
            product.ChoiceSelection();
        }
    }
}
