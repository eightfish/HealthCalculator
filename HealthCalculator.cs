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
            var bodyFatPercent = new BodyFatPercent() { BodyFatPercentNumber = bodyFatPercentNumber, PersonSex = person.sex };
            return new HealthStatus(BMINumber, bodyFatPercent);
        }

        public static BestWeightRange Suggest(Person person)
        {
            var bestBMINumberRange = HealthStatus.BestBMINumberRange;
            var bestBodyFatPercentRange = person.sex == Sex.male ? HealthStatus.MaleBestBodyFatPercentNumberRange : HealthStatus.FemaleBestBodyFatPercentNumberRange;

            var minWeightOfBMI = CalculateBestWeightOfBMI(bestBMINumberRange.Item1, person);
            var maxWeightOfBMI = CalculateBestWeightOfBMI(bestBMINumberRange.Item2, person);
            var weightRangeOfBMI = new Tuple<double, double>(minWeightOfBMI, maxWeightOfBMI);

            var minWeightOfBodyFatPercent = CalculateBestWeightOfBodyFatPercent(bestBodyFatPercentRange.Item1, person);
            var maxWeightOfBodyFatPercent = CalculateBestWeightOfBodyFatPercent(bestBodyFatPercentRange.Item2, person);
            var weightRangeOfBodyFatPercent = new Tuple<double, double>(minWeightOfBodyFatPercent, maxWeightOfBodyFatPercent);
            return new BestWeightRange() { WeightRangeOfBMI = weightRangeOfBMI, WeightRangeOfBodyFatPercent = weightRangeOfBodyFatPercent};
        }

        private static double CalculateBMINumber(Person person)
        {
            return person.weight / Math.Pow(person.height, 2);
        }

        private static double CalculateBodyFatPercentNumber(double BMINumber, Person person)
        {
            return 1.2 * BMINumber + 0.23 * person.age - 5.4 - 10.8 * (int)person.sex;
        }

        private static double CalculateBestWeightOfBMI(double BMINumber, Person person)
        {
            return Math.Pow(person.height, 2) * BMINumber;
        }

        private static double CalculateBestWeightOfBodyFatPercent(double bodyFatPercent, Person person)
        {
            double BMINumber = (bodyFatPercent - 0.23 * person.age + 5.4 + 10.8 * (int)person.sex) / 1.2;
            return CalculateBestWeightOfBMI(BMINumber, person);
        }
    }
}
