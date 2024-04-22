using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public interface IFeedbackService
    {
        void CollectFeedback(string feedback);
    }
}
