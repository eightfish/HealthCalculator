using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator
{
    static class HealthCalculator
    {
        public static HealthStatus Analyze(Person person)
        {
            double BMINumber = CalculateBMINumber(person);
            double bodyFatPercentNumber = CalculateBodyFatPercentNumber(BMINumber, person);
            return new HealthStatus(BMINumber, new BodyFatPercent() { BodyFatPercentNumber = bodyFatPercentNumber, PersonSex = person.sex });
        }

        private static double CalculateBestBMINumber(Person person)
        {

            return 0;
        }

        private static double CalculateBMINumber(Person person)
        {
            return person.weight / Math.Pow(person.height, 2);
        }

        private static double CalculateBodyFatPercentNumber(double BMINumber, Person person)
        {
            return 1.2 * BMINumber + 0.23 * person.age - 5.4 - 10.8 * (int)person.sex;
        }
    }
}
