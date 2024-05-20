using LINQUnderstanding.Model;

namespace LINQUnderstanding
{
    internal class Program
    {
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + "_" + author.AuLname);
            }
            Console.WriteLine("--------------------------------");
            var authors_ = context.Authors.ToList();
            foreach (var author in authors_)
            {
                Console.WriteLine(author.AuFname + "_" + author.AuLname);
            }
        }


        void PrintNumberOfBooksBasedOnType(string Type)
        {
            pubsContext context = new pubsContext();
            var titles = context.Titles.Where(n => n.Type == Type);
            foreach(var title in titles)
            {
                Console.WriteLine(title.Title1);
            }
            var titles_ = context.Titles.Where(n => n.Type == Type).Count();
            Console.WriteLine(titles_);
        }


        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.Key);
        //        Console.WriteLine(" - " + book.TitleCount);
        //    }
        //}
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new
        //                {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.PublisherId);
        //        Console.WriteLine(" - " + book.TitleCount);
        //        foreach (var title in book.Titles)
        //        {
        //            Console.WriteLine("\t" + title.BookName + " " + title.BookPrice);
        //        }
        //    }
        //}

        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }



        // Print the TitleId and the same Quantity and order id for every title

        void PrintTitleIdAndQuantity()
        {
            pubsContext context = new pubsContext(); 
            var titles = context.Sales
                                    .GroupBy(s => s.TitleId)
                                    .Select(g => new
                                    {
                                        TitleId = g.Key,
                                        TotalQuantity = g.Sum(s => s.Qty),
                                        Sales = g.Select(s => new { s.Qty, s.OrdNum }).ToList()
                                    });

            foreach (var title in titles)
            {
                Console.WriteLine($"TitleId: {title.TitleId}, Total Quantity: {title.TotalQuantity}");
                foreach (var sale in title.Sales)
                {
                    Console.WriteLine($"\t\tTitleId: {title.TitleId},Quantity: {sale.Qty}, OrderId: {sale.OrdNum}");
                }
            }
        }
        

        static void Main(string[] args)
        {
            Program program = new Program();
            // program.PrintAuthorNames();

            // program.PrintNumberOfBooksBasedOnType("business");
            //program.PrintTheBooksPulisherwise();
            program.PrintTitleIdAndQuantity();
            
        }
    }
}
