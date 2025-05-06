using System;
using System.Collections;
using System.Diagnostics.Metrics;

namespace Employee_Management_System
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
    class PermanentEmployee : Employee
    {
        public DateOnly JoiningDate { get; set; }
        public bool HasInsuranceCoverage { get; set; }
        public int LeaveEncashmentBalance { get; set; }
    }
    class ContractEmployee : Employee
    {
        public int ContractDurationMonths { get; set; }
        public bool isRemote { get; set; }
    }
    public class Program
    {
        public static void viewAllEmployee(Hashtable Employement)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine(
                $"{"Employee_ID",-15}" +
                $"{"Employee_Name",-20}" +
                $"{"Department",-15}" +
                $"{"Salary",-10}" +
                $"{"JoiningDate",-15}" +
                $"{"Insurance",-12}" +
                $"{"LeaveBalance",-15}" +
                $"{"ContractMonths",-17}" +
                $"{"Is_Remote",-10}");

            //Console.WriteLine("Employee_ID\t\tEmployee_Names\t\tDepartment\t\tSalary\t\tJoiningDate\t\tInsuranceCoverage\t\tLeaveEncashmentBalance\t\tContractDurationMonths\t\tIs_Remote                                                            ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (DictionaryEntry i in Employement)
            {
                var emp = i.Value; ;

                if(emp is PermanentEmployee p)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"{p.EmployeeID,-15}" +
                        $"{p.EmpName,-20}" +
                        $"{p.Department,-15}" +
                        $"{p.Salary,-10}" +
                        $"{p.JoiningDate,-15}" +
                        $"{p.HasInsuranceCoverage,-12}" +
                        $"{p.LeaveEncashmentBalance,-15}" +
                        $"  - \t\t" +
                        $"  - \t\t\t");
                    //Console.WriteLine($"{p.EmployeeID}\t\t\t{p.EmpName}\t\t\t{p.Department}\t\t{p.Salary}\t\t{p.JoiningDate}\t\t{p.HasInsuranceCoverage}\t\t\t{p.LeaveEncashmentBalance}\t\t\t - \t\t\t\t -                                                                                                           ");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (emp is ContractEmployee c)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(
                        $"{c.EmployeeID,-15}" +
                        $"{c.EmpName,-20}" +
                        $"{c.Department,-15}" +
                        $"{c.Salary,-10}" +
                        $"- \t\t" +
                        $"   -\t\t" +
                        $"-\t\t" +
                        $"{c.ContractDurationMonths,-17}" +
                        $"{c.isRemote,-10}");
                    //Console.WriteLine($"{c.EmployeeID}\t\t\t{c.EmpName}\t\t\t{c.Department}\t\t{c.Salary}\t\t - \t\t - \t\t - \t\t  {c.ContractDurationMonths}\t\t\t{c.isRemote}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
        }
        public static bool isValidString(string word)
        {
            bool flag = true;
            //if(word == null)
            //{
            //    flag = false;
            //}
            if (!char.IsDigit(word[0]) || !char.IsDigit(word[1]) || !char.IsDigit(word[2]))
            {
                flag = false;
            }

            return flag;
        }
        public static int EmpId = 106;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------ Employee Management System -----------------------------");
            Console.WriteLine("||      ||       ||      ||       ||       ||      ||       ||       ||      ||      ||");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                 Choose the Options                                    ");
            Console.ResetColor();
            Console.WriteLine("                                 1. Create a New Permanent Employee                    ");
            Console.WriteLine("                                 2. Create a New Contract Employee                     ");
            Console.WriteLine("                                 3. Delete a Employee                                  ");
            Console.WriteLine("                                 4. Exit                                               ");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Hashtable Employement = new Hashtable()
            {
                {101, new PermanentEmployee {
                    EmployeeID = 101,
                    EmpName = "Thamizh",
                    Department = "Development",
                    Salary = 75000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2020, 5, 15)),
                    HasInsuranceCoverage = true,
                    LeaveEncashmentBalance = 12
                } },
                {102, new ContractEmployee {
                    EmployeeID = 102,
                    EmpName = "Sabari",
                    Department = "Development",
                    Salary = 55000,
                    ContractDurationMonths = 12,
                    isRemote = true
                } },
                {103, new PermanentEmployee {
                    EmployeeID = 103,
                    EmpName = "Sharmila",
                    Department = "HR",
                    Salary = 60000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2020, 5, 15)),
                    HasInsuranceCoverage = true,
                    LeaveEncashmentBalance = 15
                }},
                {104, new ContractEmployee {
                    EmployeeID = 104,
                    EmpName = "Subha",
                    Department = "Development",
                    Salary = 55000,
                    ContractDurationMonths = 12,
                    isRemote = true
                }},
                {105, new ContractEmployee {
                    EmployeeID = 105,
                    EmpName = "Raj",
                    Department = "Marketing",
                    Salary = 50000,
                    ContractDurationMonths = 6,
                    isRemote = false
                } },
                {106, new PermanentEmployee {
                    EmployeeID = 106,
                    EmpName = "Lakshmi",
                    Department = "QA",
                    Salary = 65000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2021, 3, 25)),
                    HasInsuranceCoverage = false,
                    LeaveEncashmentBalance = 8
                }}
            };




            while (true)
            {
                int choice = 0;
            Choice:
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Choice for the Employee Management System : ");
                    Console.ResetColor();
                    int Choice = int.Parse(Console.ReadLine());
                    choice = Choice;
                    Console.WriteLine();
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalod Choice! Enter the Choice in Digit not in Alphabet, Special Characters and Whitespace");
                    Console.ResetColor();
                    goto Choice;
                }

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                    Enter '1' to create a new permanent employee                       ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        PermanentEmployee permanent = new PermanentEmployee();

                        Name:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Employee Name : ");
                        Console.ResetColor();
                        string empName = Console.ReadLine();
                        if (empName == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee Name should not be Empty");
                            Console.ResetColor();
                            goto Name;

                        }
                        if (isValidString(empName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Employee name should contain only letters and must not include special characters or numbers.");
                            Console.ResetColor();
                            goto Name;
                        }
                        permanent.EmpName = empName;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Department : ");
                        Console.ResetColor();
                        String department = Console.ReadLine();
                        permanent.Department = department;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Salary : ");
                        Console.ResetColor();
                        double salary = double.Parse(Console.ReadLine());
                        permanent.Salary = salary;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Date (yyyy-MM-dd): ");
                        Console.ResetColor();
                        string inputDate = Console.ReadLine();  

                        if(DateOnly.TryParse(inputDate, out DateOnly joiningDate))
                        {
                            permanent.JoiningDate = joiningDate;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Does the employee have insurance coverage ? (Y / N) :");
                        Console.ResetColor();
                        char ch = char.Parse(Console.ReadLine());
                        if (ch == 'y' || ch == 'Y')
                        {
                            permanent.HasInsuranceCoverage = true;
                        }
                        if (ch == 'n' || ch == 'N')
                        {
                            permanent.HasInsuranceCoverage = false;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter Leave Encashment Balance : ");
                        Console.ResetColor();
                        permanent.LeaveEncashmentBalance = int.Parse(Console.ReadLine());

                        EmpId++;
                        permanent.EmployeeID = EmpId;

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Employee ID for {empName} : ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(EmpId);
                        Console.ResetColor();

                        Employement.Add(EmpId, permanent);


                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine(
                             $"{"Employee_ID",-15}" +
                             $"{"Employee_Name",-20}" +
                             $"{"Department",-15}" +
                             $"{"Salary",-10}" +
                             $"{"JoiningDate",-15}" +
                             $"{"Insurance",-12}" +
                             $"{"LeaveBalance",-15}");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        PermanentEmployee newPerEmp = (PermanentEmployee)Employement[EmpId];
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(
                        $"{newPerEmp.EmployeeID,-15}" +
                        $"{newPerEmp.EmpName,-20}" +
                        $"{newPerEmp.Department,-15}" +
                        $"{newPerEmp.Salary,-10}" +
                        $"{newPerEmp.JoiningDate,-15}" +
                        $"{newPerEmp.HasInsuranceCoverage,-12}" +
                        $"{newPerEmp.LeaveEncashmentBalance,-15}");
                        //Console.WriteLine($"{newPerEmp.EmployeeID}\t\t\t{newPerEmp.EmpName}\t\t\t{newPerEmp.Department}\t\t{newPerEmp.Salary}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Employee {EmpId} is Created Successfully :)");
                        Console.ResetColor();
                        Console.WriteLine();

                        Decision:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("If you Want to View all the Employee's Details ? (Y/N) : ");
                        Console.ResetColor();
                        char view = char.Parse( Console.ReadLine() ); 
                        if( view == 'y' || view == 'Y')
                        {
                            viewAllEmployee(Employement);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (view == 'n' || view == 'N')
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("~ * Okay...!!! * ~");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the decision properly using only 'y' or 'n'");
                            Console.ResetColor();
                            goto Decision;
                        }

                        Con:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Do you want to continue creating the employee? (Y/N): ");
                        Console.ResetColor();
                        char con = char.Parse( Console.ReadLine() );    
                        if(con == 'y'||con == 'Y')
                        {
                            goto Name;
                        }
                        else if( con == 'n' || con == 'N')
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("~ * Thank You...!!! * ~");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the decision properly using only 'y' or 'n'");
                            Console.ResetColor();
                            goto Con;
                        }

                        break;
                }
            }
        }
    }
}
