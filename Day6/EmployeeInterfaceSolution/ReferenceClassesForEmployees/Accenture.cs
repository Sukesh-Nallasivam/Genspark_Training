using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceClassesForEmployees
{
    public class Accenture:GovernmentRules
    {
        public int EmployeeID {  get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartment { get; set; }
        public float ServiceCompleted { get; set; }
        public double BasicSalary {  get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <param name="employeeDepartment"></param>
        ///// <param name="basicSalary"></param>
        ///// <param name="serviceCompleted"></param>
        public Accenture(int employeeID, string employeeName, string employeeDepartment)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeDepartment = employeeDepartment;
            //BasicSalary = basicSalary;
            //ServiceCompleted = serviceCompleted;
        }

        public void CompanyDetail()
        {
            Console.WriteLine("This is Accenture");

        }
        public double EmployeePF(double BasicSalary)
        {
            double PF = 0.12 * BasicSalary;
            Console.WriteLine($"PF contribution of {EmployeeName} is\t:\t{PF}");
            double EmployerContribution = 0.0833 * BasicSalary;
            Console.WriteLine($"PF contributed by Employer to {EmployeeName} is\t:\t{EmployerContribution} Per Year");
            double EmployeeContribution = 0.0367 * BasicSalary;
            return EmployeeContribution;
        }
        public string LeaveDetails()
        {
            int CasualLeave = 2;
            int SickLeave = 5;
            int PrevilegeLeave = 5;
            string LeaveDetails = $"CasualLeave\t:\t{CasualLeave} Per Month\t|\tSickLeave\t:\t{SickLeave} Per Year\t|\tPrevilegeLeave\t:\t{PrevilegeLeave}";
            return LeaveDetails ;
        }
        public double? GratuityAmount(float ServiceCompleted, double BasicSalary)
        {
            return null;
        }

        public void EmployeeDetail()
        {
            Console.WriteLine($"Name\t:\t{EmployeeName}");
            Console.WriteLine($"Department\t:\t{EmployeeDepartment}");
            
        }

    }
}
