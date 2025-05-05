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
        public double Salary { get; set}
    }
    class PermanentEmployee : Employee
    {
        public DateOnly JoiningDate { get; set; }
        public bool HasInsuranceCoverage { get; set; }  
        public int LeaveEncashmentBalance { get; set; }
    }
    class ContractEmployee : Employee
    {
        public int ContractDurationMonths {  get; set; }   
        public bool isRemote { get; set; }
    }
    public class Program
    {
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
                    Console.WriteLine("Enter the Choice for the Employee Management System : ");
                    Console.ResetColor();
                    int Choice = int.Parse(Console.ReadLine());
                    choice = Choice;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalod Choice! Enter the Choice in Digit not in Alphabet, Special Characters and Whitespace");
                    Console.ResetColor();
                    goto Choice;
                }

                switch(choice)
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
                        Console.Write("Enter the Date : ");
                        Console.ResetColor();
                        permanent.JoiningDate = DateOnly.FromDateTime(DateTime.Now);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Does the employee have insurance coverage ? (Y / N) :");
                        Console.ResetColor();
                        char ch = char.Parse(Console.ReadLine());
                        if(ch == 'y' || ch == 'Y')
                        {
                            permanent.HasInsuranceCoverage = true;
                        }
                        if(ch == 'n' || ch == 'N')
                        {
                            permanent.HasInsuranceCoverage = false;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter Leave Encashment Balance : ");
                        Console.ResetColor();
                        permanent.LeaveEncashmentBalance = int.Parse(Console.ReadLine());

                        EmpId++;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Employee ID : ");
                        Console.ResetColor();
                        Console.WriteLine(EmpId);

                        Employement.Add(EmpId, permanent);


                }
            }
        }
    }
}