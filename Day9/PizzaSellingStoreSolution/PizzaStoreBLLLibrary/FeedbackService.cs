using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public class FeedbackService:IFeedbackService
    {
        void IFeedbackService.CollectFeedback(string feedback)
        {
           Console.WriteLine("Thank you");
        }
    }
}
