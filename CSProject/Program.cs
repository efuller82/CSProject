using System;
using System.Collections.Generic;
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

        public int Allowance { get; private set; } = 1000;
        
        public override void CalculatePay()
        {
            base.CalculatePay();
            // not sure about this if/else statement
            if (HoursWorked > 160)
                TotalPay += 1000;
            else
                TotalPay = TotalPay;
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

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
