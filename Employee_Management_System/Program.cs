using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Employee_Management_System
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
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
        public static bool isValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }
        public static void viewAllEmployee(Hashtable Employement)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine(
                $"{"Employee_ID",-15}" +
                $"{"Employee_Name",-20}" +
                $"{"Email",-25}" +
                $"{"Department",-15}" +
                $"{"Salary",-10}" +
                $"{"JoiningDate",-15}" +
                $"{"Insurance",-12}" +
                $"{"LeaveBalance",-15}" +
                $"{"ContractMonths",-17}" +
                $"{"Is_Remote",-10}"
            );

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            var sortedEmployment = Employement.Cast<DictionaryEntry>()
                                              .OrderBy(entry => entry.Key);

            foreach (DictionaryEntry i in sortedEmployment)
            {
                var emp = i.Value;

                if (emp is PermanentEmployee p)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(
                        $"{p.EmployeeID,-15}" +
                        $"{p.EmpName,-20}" +
                        $"{p.Email,-25}" +
                        $"{p.Department,-15}" +
                        $"{p.Salary,-10}" +
                        $"{p.JoiningDate,-15}" +
                        $"{p.HasInsuranceCoverage,-12}" +
                        $"{p.LeaveEncashmentBalance,-15}" +
                        $"{"-",-17}" +
                        $"{"-",-10}"
                    );
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (emp is ContractEmployee c)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(
                        $"{c.EmployeeID,-15}" +
                        $"{c.EmpName,-20}" +
                        $"{c.Email,-25}" +
                        $"{c.Department,-15}" +
                        $"{c.Salary,-10}" +
                        $"{"-",-15}" +
                        $"{"-",-12}" +
                        $"{"-",-15}" +
                        $"{c.ContractDurationMonths,-17}" +
                        $"{c.isRemote,-10}"
                    );
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
        public static bool isValidString(string word)
        {
            bool flag = true;
            if (!char.IsDigit(word[0]) || !char.IsDigit(word[1]) || !char.IsDigit(word[2]))
            {
                flag = false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(word, @"[a-zA-Z]+$"))
            {
                flag = false;
            }

            return flag;
        }
        public static int EmpId = 106;
        static void Main(string[] args)
        {
            Hashtable Employement = new Hashtable()
            {
                {101, new PermanentEmployee {
                    EmployeeID = 101,
                    EmpName = "thamizh",
                    Email = "thamizh@gmail.com",
                    Department = "development",
                    Salary = 75000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2020, 5, 15)),
                    HasInsuranceCoverage = true,
                    LeaveEncashmentBalance = 12
                } },
                {102, new ContractEmployee {
                    EmployeeID = 102,
                    EmpName = "tabari",
                    Email = "sabari@gmail.com",
                    Department = "development",
                    Salary = 55000,
                    ContractDurationMonths = 12,
                    isRemote = true
                } },
                {103, new PermanentEmployee {
                    EmployeeID = 103,
                    EmpName = "Sharmila",
                    Email = "sharmila@gmail.com",
                    Department = "hr",
                    Salary = 60000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2020, 5, 15)),
                    HasInsuranceCoverage = true,
                    LeaveEncashmentBalance = 15
                }},
                {104, new ContractEmployee {
                    EmployeeID = 104,
                    EmpName = "subha",
                    Email = "subha@gmail.com",
                    Department = "development",
                    Salary = 55000,
                    ContractDurationMonths = 12,
                    isRemote = true
                }},
                {105, new ContractEmployee {
                    EmployeeID = 105,
                    EmpName = "raj",
                    Email = "raj@gmail.com",
                    Department = "marketing",
                    Salary = 50000,
                    ContractDurationMonths = 6,
                    isRemote = false
                } },
                {106, new PermanentEmployee {
                    EmployeeID = 106,
                    EmpName = "lakshmi",
                    Email = "lakshmi@gmail.com",
                    Department = "qa",
                    Salary = 65000,
                    JoiningDate = DateOnly.FromDateTime(new DateTime(2021, 3, 25)),
                    HasInsuranceCoverage = false,
                    LeaveEncashmentBalance = 8
                }}
            };


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.WriteLine("                                 4. View all Employee                                  ");
                Console.WriteLine("                                 5. Exit                                               ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();

                int choice = 0;
                Choice:
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Choice for the Employee Management System : ");
                    Console.ResetColor();
                    int Choice = int.Parse(Console.ReadLine());
                    if (Choice > 6 || Choice == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choice Must be Less than 6 and not must be Zero");
                        Console.ResetColor();
                        goto Choice;
                    }
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
                        if (empName.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee Name should not be Empty");
                            Console.ResetColor();
                            goto Name;

                        }
                        if(empName.Length < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Length of Employee Name should be Greater than 3");
                            Console.ResetColor();
                            goto Name;
                        }
                        if (isValidString(empName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee name should contain only letters and must not include special characters or numbers.");
                            Console.ResetColor();
                            goto Name;
                        }
                        permanent.EmpName = empName;

                    Email:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Email : ");
                        Console.ResetColor();
                        string PerEmail = Console.ReadLine();
                        if (PerEmail.Length == 0 || PerEmail == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please Enter Your  Email  :(");
                            Console.ResetColor();
                            goto Email;
                        }
                        if (!isValidEmail(PerEmail))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Email! Enter the Valid Email :(");
                            Console.ResetColor();
                            goto Email;
                        }
                        permanent.Email = PerEmail;

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

                        if (DateOnly.TryParse(inputDate, out DateOnly joiningDate))
                        {
                            permanent.JoiningDate = joiningDate;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                            Console.ResetColor();
                        }
                        Desicion:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Does the employee have insurance coverage ? (Y / N) :");
                        Console.ResetColor();
                        char ch = char.Parse(Console.ReadLine());
                        if (ch == 'y' || ch == 'Y')
                        {
                            permanent.HasInsuranceCoverage = true;
                        }
                        else if (ch == 'n' || ch == 'N')
                        {
                            permanent.HasInsuranceCoverage = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Decision correctly (only 'Y' or 'N')");
                            Console.ResetColor();
                            goto Desicion;
                        }
                           Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter Leave Encashment Balance : ");
                        Console.ResetColor();
                        permanent.LeaveEncashmentBalance = int.Parse(Console.ReadLine());

                        EmpId++;
                        permanent.EmployeeID = EmpId;

                        foreach (DictionaryEntry i in Employement)
                        {
                            var values = i.Value;
                            if (values is PermanentEmployee p)
                            {
                                if (p.Email == PerEmail && p.EmpName == empName)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Employee Already Exit");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    goto Name;

                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Employee ID for {empName} : ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(EmpId);
                        Console.ResetColor();

                        Employement.Add(EmpId, permanent);


                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine(
                             $"{"Employee_ID",-15}" +
                             $"{"Employee_Name",-20}" +
                             $"{"Employee_Email",-15}" +
                             $"\t{"Department",-15}" +
                             $"{"Salary",-10}" +
                             $"{"JoiningDate",-15}" +
                             $"{"Insurance",-12}" +
                             $"{"LeaveBalance",-15}");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        PermanentEmployee newPerEmp = (PermanentEmployee)Employement[EmpId];

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(
                        $"{newPerEmp.EmployeeID,-15}" +
                        $"{newPerEmp.EmpName,-20}" +
                        $"{newPerEmp.Email,-15}" +
                        $"\t{newPerEmp.Department,-15}" +
                        $"{newPerEmp.Salary,-10}" +
                        $"{newPerEmp.JoiningDate,-15}" +
                        $"{newPerEmp.HasInsuranceCoverage,-12}" +
                        $"{newPerEmp.LeaveEncashmentBalance,-15}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"New Permanent Employee {EmpId} is Created Successfully :)");
                        Console.ResetColor();
                        Console.WriteLine();

                    Decision:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("If you Want to View all the Employee's Details ? (Y/N) : ");
                        Console.ResetColor();
                        char view = char.Parse(Console.ReadLine());
                        if (view == 'y' || view == 'Y')
                        {
                            viewAllEmployee(Employement);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
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

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any Key to Continue....");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);
                        //Con:
                        //Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Console.Write("Do you want to continue creating the employee? (Y/N): ");
                        //Console.ResetColor();
                        //char con = char.Parse( Console.ReadLine() );    
                        //if(con == 'y'||con == 'Y')
                        //{
                        //    goto Name;
                        //}
                        //else if( con == 'n' || con == 'N')
                        //{
                        //    Console.WriteLine();
                        //    Console.ForegroundColor = ConsoleColor.Magenta;
                        //    Console.WriteLine("~ * Thank You...!!! * ~");
                        //    Console.ResetColor();
                        //    Console.WriteLine();
                        //}
                        //else
                        //{
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.WriteLine("Enter the decision properly using only 'y' or 'n'");
                        //    Console.ResetColor();
                        //    goto Con;
                        //}

                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                    Enter '2' to create a new Contract employee                       ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        ContractEmployee contract = new ContractEmployee();
                    ConEmpName:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Employee Name : ");
                        Console.ResetColor();
                        string ConEmpName = Console.ReadLine();
                        if (ConEmpName == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee Name should not be Empty");
                            Console.ResetColor();
                            goto ConEmpName;

                        }
                        if (isValidString(ConEmpName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Employee name should contain only letters and must not include special characters or numbers.");
                            Console.ResetColor();
                            goto ConEmpName;
                        }
                        contract.EmpName = ConEmpName;

                    ContractEmail:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Email : ");
                        Console.ResetColor();
                        string ConEmail = Console.ReadLine();
                        if (ConEmail.Length == 0 || ConEmail == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the Email :(");
                            Console.ResetColor();
                            goto ContractEmail;
                        }
                        if (!isValidEmail(ConEmail))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Email! Enter the Valid Email :(");
                            Console.ResetColor();
                            goto ContractEmail;
                        }
                        contract.Email = ConEmail;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Department : ");
                        Console.ResetColor();
                        contract.Department = Console.ReadLine(); ;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Salary : ");
                        Console.ResetColor();
                        contract.Salary = double.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Contract Diration (in Month) : ");
                        Console.ResetColor();
                        contract.ContractDurationMonths = int.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Does the employee work remotely? (Y/N) : ");
                        Console.ResetColor();
                        char remote = char.Parse(Console.ReadLine());
                        if (remote == 'y' || remote == 'Y')
                        {
                            contract.isRemote = true;
                        }
                        if (remote == 'n' || remote == 'N')
                        {
                            contract.isRemote = false;
                        }

                        foreach (DictionaryEntry i in Employement)
                        {
                            var values = i.Value;
                            if (values is ContractEmployee c)
                            {
                                if (c.Email == ConEmail && c.EmpName == ConEmpName)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Employee Already Exit");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    goto ConEmpName;

                                }
                            }
                        }

                        EmpId++;
                        contract.EmployeeID = EmpId;

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Employee ID for {ConEmpName} : ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(EmpId);
                        Console.ResetColor();

                        Employement.Add(EmpId, contract);

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine(
                             $"{"Employee_ID",-15}" +
                             $"{"Employee_Name",-20}" +
                             $"{"Employee_Name",-15}" +
                             $"\t{"Department",-15}" +
                             $"{"Salary",-10}" +
                             $"{"ContractDuration",-15}" +
                             $"\t{"Remote",-12}");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        ContractEmployee newConEmp = (ContractEmployee)Employement[EmpId];

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(
                        $"{newConEmp.EmployeeID,-15}" +
                        $"{newConEmp.EmpName,-20}" +
                        $"{newConEmp.Email,-15}" +
                        $"\t{newConEmp.Department,-15}" +
                        $"{newConEmp.Salary,-10}" +
                        $"{newConEmp.ContractDurationMonths,-15}" +
                        $"\t{newConEmp.isRemote,-12}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"New Contract Employee {EmpId} is Created Successfully :)");
                        Console.ResetColor();
                        Console.WriteLine();

                    Decision1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("If you Want to View all the Employee's Details ? (Y/N) : ");
                        Console.ResetColor();
                        char viewCon = char.Parse(Console.ReadLine());
                        if (viewCon == 'y' || viewCon == 'Y')
                        {
                            viewAllEmployee(Employement);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (viewCon == 'n' || viewCon == 'N')
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
                            goto Decision1;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any Key to Continue....");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any Key to Continue....");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);

                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                           Enter '3' to Delete a employee                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        viewAllEmployee(Employement);
                    EmpId:
                        int empIdToRemove = 0;
                        try
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Enter the Employee ID to Delete : ");
                            Console.ResetColor();
                            int empId = int.Parse(Console.ReadLine());
                            empIdToRemove = empId;
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter the ID using digits only — no letters, special characters, or whitespace.");
                            Console.ResetColor();
                            goto EmpId;
                        }

                        if (Employement.ContainsKey(empIdToRemove))
                        {
                            Employement.Remove(empIdToRemove);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"Employee Id {empIdToRemove} is Successfully Removed !! :)");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Employee Id {empIdToRemove} is Not Found \nRe-Enter the Employee ID Again");
                            Console.ResetColor();
                            goto EmpId;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any Key to Continue....");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);
                        break;

                    case 4:

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                            Enter '4' to View all employee                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        viewAllEmployee(Employement);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any Key to Continue....");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);

                        break;

                    case 5:

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("                     You Choose to Exist :)                  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();

                        for (int i = 5; i > 0; i--)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("                 Existing From Grocery: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" {i} ");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                        }
                        break;
                }
                if (choice == 5)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                      ~ * Thank You * ~                    ");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
