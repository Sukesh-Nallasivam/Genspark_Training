using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaStoreDALLibrary;

namespace PizzaStoreBLLLibrary
{
    public class ReportService:IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService()
        {
            IReportRepository reportRepository = _reportRepository;
        }


        public int ChooseReport()
        {
            Console.WriteLine("Enter Choice");
            return 1;
        }
        public void GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            _reportRepository.GenerateSalesReport(startDate, endDate);
        }

        public void GenerateInventoryStatusReport()
        {
            _reportRepository.GenerateInventoryStatusReport();
        }

        public void GenerateDeliveryPerformanceReport(DateTime startDate, DateTime endDate)
        {
            _reportRepository.GenerateDeliveryPerformanceReport(startDate, endDate);
        }
    }
}
