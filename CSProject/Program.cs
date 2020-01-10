using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSProject
{

    
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            BasicPay = hWorked * hourlyRate;

            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "hourlyRate = " + hourlyRate + ", hworked = " + hWorked + ", Name of Staff = " + NameOfStaff; 
        }

    }

    class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public Manager(string name) : base(name, managerHourlyRate) { }

        public int Allowance { get; private set; }
        
        public override void CalculatePay()
        {
            base.CalculatePay();

            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            // not sure about this
            return base.ToString();
        }
    }

    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public Admin(string name) : base(name, adminHourlyRate) { }

        // Not sure about any of this
        public float Overtime {
            get
            {
                return Overtime;
            }
            private set
            {
                Overtime = overtimeRate * (HoursWorked - 160);
            }
        } 

        public override void CalculatePay()
        {
            // not sure about this if/else statement, much like Manager class
            base.CalculatePay();
            if (HoursWorked > 160)
                TotalPay += Overtime;
            else
                TotalPay = TotalPay;               
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { "," };

            if (File.Exists("staff.txt"))
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                    sr.Close();
                }
            else
                Console.WriteLine("There is an error");

            return myStaff;
        }
        
    }

    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR = 3, APR = 4, MAY = 5, JUN = 6, JUL = 7, AUG = 8, SEP = 9, OCT = 10, NOV = 11, DEC = 12
        }

        public PaySlip(int payMonth, int payYear) { }

        public void GeneratePaySlip(List<Staff>myStaff)
        {
            string path;
            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("=======================");
                sw.WriteLine("Name Of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0}", Convert.ToInt32(f.BasicPay));

                if (f.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0: C}", ((Manager)f).Allowance);
                else if (f.GetType() == typeof(Admin))
                    sw.WriteLine("Overtime: {0: C}", ((Admin)f).Overtime);

                sw.WriteLine("");
                sw.WriteLine("======================");

                sw.WriteLine("Total Pay: {0: C}", f.TotalPay);

                sw.WriteLine("======================");
                
                sw.Close();
            }
        }

        public void GenerateSummary()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
