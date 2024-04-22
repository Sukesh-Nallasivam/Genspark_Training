using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreBLLLibrary
{
    public interface IReportService
    {
        void GenerateSalesReport(DateTime startDate, DateTime endDate);
        void GenerateInventoryStatusReport();
        void GenerateDeliveryPerformanceReport(DateTime startDate, DateTime endDate);
        int ChooseReport();
    }
}
