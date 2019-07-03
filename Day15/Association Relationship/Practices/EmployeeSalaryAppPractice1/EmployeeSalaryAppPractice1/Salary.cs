using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryAppPractice1
{
    public class Salary
    {
        private int noOfIncrement=0;
        private double basic;
        private double rateOfMedical;
        private double rateOfConveyance;
        //private double medical;
        //private double conveyance;
        public int NoOfIncrement
        {
            get
            {
                return noOfIncrement;
            }
        }
        public double RateOfMedical
        {
            set
            {
                rateOfMedical = value;
            }
        }
        public double RateOfConveyance
        {
            set
            {
                rateOfConveyance = value;
            }
        }
        public double Basic
        {
            get
            {
                return basic;
            }
            set
            {
                basic = value;
            }
           

        }
        public double Medical
        {
            get
            {
                return rateOfMedical * Basic / 100;
                //return medical;
            }
        } 
        public double Conveyance
        {
            get
            {
                return rateOfConveyance * Basic / 100;
                //return conveyance;
            }
        }
        public bool Increment(double rateOfIncrement)
        {
            noOfIncrement++;
            basic += rateOfIncrement * basic / 100;
            //medical = basic * rateOfMedical / 100;
            //conveyance = basic * rateOfConveyance / 100;
            return true;
        } 
        public double Total
        {
            get
            {
                return Basic + Medical + Conveyance;
            }
        }
    }
}
