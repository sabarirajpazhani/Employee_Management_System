using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Employee_Management_System
{
    
    abstract class Employee
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(int EmployeeID, string EmpName, string Email, string Department, double Salary)
        {
            this.EmployeeID = EmployeeID; ;
            this.EmpName = EmpName;
            this.Email = Email;
            this.Department = Department;
            this.Salary = Salary;
        }

        public abstract void DisplayTableRow();
    }
    class PermanentEmployee : Employee
    {
        public DateOnly JoiningDate { get; set; }
        public bool HasInsuranceCoverage { get; set; }
        public int LeaveEncashmentBalance { get; set; }

        public PermanentEmployee(int EmployeeID, string EmpName, string Email, string Department, double Salary, DateOnly JoiningDate, bool HasInsuranceCoverage, int LeaveEncashmentBalance) : base(EmployeeID, EmpName, Email, Department, Salary)
        {
            this.JoiningDate = JoiningDate;
            this.HasInsuranceCoverage = HasInsuranceCoverage;
            this.LeaveEncashmentBalance = LeaveEncashmentBalance;
        }
        public override void DisplayTableRow()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                 $"{EmployeeID,-15}" +
                 $"{EmpName,-20}" +
                 $"{Email,-15}" +
                 $"\t{Department,-15}" +
                 $"{Salary,-10}" +
                 $"{JoiningDate,-15}" +
                 $"{HasInsuranceCoverage,-12}" +
                 $"{LeaveEncashmentBalance,-15}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    class ContractEmployee : Employee
    {
        public int ContractDurationMonths { get; set; }
        public bool isRemote { get; set; }

        public ContractEmployee(int EmployeeID, string EmpName, string Email, string Department, double Salary,int ContractDurationMonths, bool isRemote) : base(EmployeeID, EmpName, Email, Department, Salary)
        {
            this.ContractDurationMonths = ContractDurationMonths;
            this.isRemote = isRemote;
        }

        public override void DisplayTableRow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                 $"{EmployeeID,-15}" +
                 $"{EmpName,-20}" +
                 $"{Email,-15}" +
                 $"\t{Department,-15}" +
                 $"{Salary,-10}" +
                 $"{ContractDurationMonths,-15}" +
                 $"\t{isRemote,-12}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public interface EmployeeMethods                   //Interface
    {
        void viewAllEmployee(Hashtable Employeement);
        bool isValidEmail(string email);

    }
    public class EmployeeInterFace : EmployeeMethods
    {
        public bool isValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }
        public void viewAllEmployee(Hashtable Employement)
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
    }


    public class Program : EmployeeInterFace
    {
        
        
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
                { 101, new PermanentEmployee(101, "thamizh", "thamizh@gmail.com", "development", 75000, DateOnly.FromDateTime(new DateTime(2020, 5, 15)), true, 12) },
                { 102, new ContractEmployee(102, "tabari", "sabari@gmail.com", "development", 55000, 12, true) },
                { 103, new PermanentEmployee(103, "Sharmila", "sharmila@gmail.com", "hr", 60000, DateOnly.FromDateTime(new DateTime(2020, 5, 15)), true, 15) },
                { 104, new ContractEmployee(104, "subha", "subha@gmail.com", "development", 55000, 12, true) },
                { 105, new ContractEmployee(105, "raj", "raj@gmail.com", "marketing", 50000, 6, false) },
                { 106, new PermanentEmployee(106, "lakshmi", "lakshmi@gmail.com", "qa", 65000, DateOnly.FromDateTime(new DateTime(2021, 3, 25)), false, 8) }
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

                //EmployeeInterFace emp = new Program();
                EmployeeInterFace emp = new Program();

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

                int EmployeeID = 0;
                string EmpName = "Empty";
                string Email = "Empty";
                string Department = "Empty";
                double Salary = 0;
                DateOnly JoiningDate = DateOnly.FromDateTime(new DateTime(2020, 5, 15));
                bool HasInsuranceCoverage = false;
                int LeaveEncashmentBalance = 0;
                int ContractDurationMonths = 0;
                bool isRemote = false;
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

                        if (isValidString(empName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee name should contain only letters and must not include special characters or numbers.");
                            Console.ResetColor();
                            goto Name;
                        }

                        if (empName.Length < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Length of Employee Name should be Greater than 3");
                            Console.ResetColor();
                            goto Name;
                        }
                        EmpName = empName;

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
                        if (!emp.isValidEmail(PerEmail))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Email! Enter the Valid Email :(");
                            Console.ResetColor();
                            goto Email;
                        }
                        Email = PerEmail;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Department : ");
                        Console.ResetColor();
                        String department = Console.ReadLine();
                        Department = department;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Salary : ");
                        Console.ResetColor();
                        double salary = double.Parse(Console.ReadLine());
                        Salary = salary;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Date (yyyy-MM-dd): ");
                        Console.ResetColor();
                        string inputDate = Console.ReadLine();

                        if (DateOnly.TryParse(inputDate, out DateOnly joiningDate))
                        {
                            JoiningDate = joiningDate;
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
                            HasInsuranceCoverage = true;
                        }
                        else if (ch == 'n' || ch == 'N')
                        {
                            HasInsuranceCoverage = false;
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
                        LeaveEncashmentBalance = int.Parse(Console.ReadLine());

                        EmpId++;
                        EmployeeID = EmpId;

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

                        PermanentEmployee permanent = new PermanentEmployee(EmployeeID, EmpName, Email, Department, Salary, JoiningDate, HasInsuranceCoverage, LeaveEncashmentBalance);

                        Employement.Add(EmpId, permanent);


                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
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

                        permanent.DisplayTableRow();


                        //PermanentEmployee newPerEmp = (PermanentEmployee)Employement[EmpId];

                        //Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Console.WriteLine(
                        //$"{newPerEmp.EmployeeID,-15}" +
                        //$"{newPerEmp.EmpName,-20}" +
                        //$"{newPerEmp.Email,-15}" +
                        //$"\t{newPerEmp.Department,-15}" +
                        //$"{newPerEmp.Salary,-10}" +
                        //$"{newPerEmp.JoiningDate,-15}" +
                        //$"{newPerEmp.HasInsuranceCoverage,-12}" +
                        //$"{newPerEmp.LeaveEncashmentBalance,-15}");
                        //Console.ResetColor();
                        //Console.WriteLine();
                        //Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        //Console.ResetColor();

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
                            emp.viewAllEmployee(Employement);
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
                        EmpName = ConEmpName;

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
                        if (!emp.isValidEmail(ConEmail))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Email! Enter the Valid Email :(");
                            Console.ResetColor();
                            goto ContractEmail;
                        }
                        Email = ConEmail;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Department : ");
                        Console.ResetColor();
                        Department = Console.ReadLine(); ;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Salary : ");
                        Console.ResetColor();
                        Salary = double.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Contract Diration (in Month) : ");
                        Console.ResetColor();
                        ContractDurationMonths = int.Parse(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Does the employee work remotely? (Y/N) : ");
                        Console.ResetColor();
                        char remote = char.Parse(Console.ReadLine());
                        if (remote == 'y' || remote == 'Y')
                        {
                            isRemote = true;
                        }
                        if (remote == 'n' || remote == 'N')
                        {
                            isRemote = false;
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
                        EmployeeID = EmpId;

                        ContractEmployee contract = new ContractEmployee(EmployeeID, EmpName, Email, Department, Salary, ContractDurationMonths, isRemote);

                        

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Employee ID for {ConEmpName} : ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(EmpId);
                        Console.ResetColor();

                        Employement.Add(EmpId, contract);

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
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
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        contract.DisplayTableRow();

                        //ContractEmployee newConEmp = (ContractEmployee)Employement[EmpId];

                        //Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Console.WriteLine(
                        //$"{newConEmp.EmployeeID,-15}" +
                        //$"{newConEmp.EmpName,-20}" +
                        //$"{newConEmp.Email,-15}" +
                        //$"\t{newConEmp.Department,-15}" +
                        //$"{newConEmp.Salary,-10}" +
                        //$"{newConEmp.ContractDurationMonths,-15}" +
                        //$"\t{newConEmp.isRemote,-12}");
                        //Console.ResetColor();
                        //Console.WriteLine();
                        //Console.WriteLine("---------------------------------------------------------------------------------------------------");
                        //Console.ResetColor();

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
                            emp.viewAllEmployee(Employement);
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

                        emp.viewAllEmployee(Employement);
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

                        emp.viewAllEmployee(Employement);

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
