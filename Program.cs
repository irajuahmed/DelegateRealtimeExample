using System;
using System.Collections.Generic;

namespace DelegateRealtimeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee()
            {
                ID = 101,
                Name = "Pranaya",
                Gender = "Male",
                Experience = 5,
                Salary = 10000
            };
            Employee emp2 = new Employee()
            {
                ID = 102,
                Name = "Priyanka",
                Gender = "Female",
                Experience = 10,
                Salary = 20000
            };
            Employee emp3 = new Employee()
            {
                ID = 103,
                Name = "Anurag",
                Experience = 15,
                Salary = 30000
            };
            List<Employee> lstEmployess = new List<Employee>();
            lstEmployess.Add(emp1);
            lstEmployess.Add(emp2);
            lstEmployess.Add(emp3);
            EligibleToPromotion sBasePromote = new EligibleToPromotion(SalaryBasePromote);
            EligibleToPromotion eBasePromote = new EligibleToPromotion(ExperienceBasePromote);

            //Employee.PromoteEmployee(lstEmployess, x => x.Experience > 5);
            Console.WriteLine("Salary Based Promoted Employee.\n");
            Employee.PromoteEmployee(lstEmployess, sBasePromote);

            Console.WriteLine("\n\n\nExperience Based Promoted Employee.\n");
            Employee.PromoteEmployee(lstEmployess, sBasePromote);

            Console.ReadKey();
        }

        public static bool ExperienceBasePromote(Employee employee)
        {
            return employee.Experience < 10 ? true : false;
        }

        public static bool SalaryBasePromote(Employee employee)
        {
            if (employee.Salary > 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public delegate bool EligibleToPromotion(Employee EmployeeToPromotion);
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public static void PromoteEmployee(List<Employee> lstEmployees, EligibleToPromotion IsEmployeeEligible)
        {
            foreach (Employee employee in lstEmployees)
            {
                if (IsEmployeeEligible(employee))
                {
                    Console.WriteLine("Employee {0} Promoted", employee.Name);
                }
            }
        }
    }
}
