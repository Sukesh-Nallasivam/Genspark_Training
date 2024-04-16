using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceClassesForEmployees
{
    public interface GovernmentRules
    {
        double EmployeePF(double BasicSalary);
        string LeaveDetails();
        double? GratuityAmount(float ServiceCompleted, double BasicSalary);

        void CompanyDetail();
        void EmployeeDetail();
    }
}
