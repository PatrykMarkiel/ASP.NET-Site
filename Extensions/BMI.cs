using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace WebApplication3.Helpers
{
    public static class BMI
    {
        public class BMICalculator
        {
            public double CalculateBMI(double weightInKg, double heightInCm)
            {
                double heightInMeters = heightInCm / 100;


                double bmi = weightInKg / (heightInMeters * heightInMeters);

                return bmi;
            }

            public string GetBMICategory(double bmi)
            {
                if (bmi < 18.5)
                {
                    return "Underweight";
                }
                else if (bmi >= 18.5 && bmi < 25)
                {
                    return "Normal weight";
                }
                else if (bmi >= 25 && bmi < 30)
                {
                    return "Overweight";
                }
                else if (bmi >= 30 && bmi < 35)
                {
                    return "Obese Class I";
                }
                else if (bmi >= 35 && bmi < 40)
                {
                    return "Obese Class II";
                }
                else if (bmi >= 40)
                {
                    return "Obese Class III";
                }

                return "Unknown";
            }
        }
    }
}
