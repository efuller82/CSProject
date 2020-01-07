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

        public int Allowance { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
