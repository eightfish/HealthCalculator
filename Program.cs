using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a health calculator!");

            Console.WriteLine("input your age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("input your height:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("input your weight:");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("input your Sex: (male or female)");
            Sex sex = (Sex)Enum.Parse(typeof(Sex), Console.ReadLine());

            var person = new Person() { age = age, height = height, weight = weight, sex = sex };
            var status = HealthCalculator.Analyze(person);

            Console.WriteLine(string.Format("Result: is Healthy? (true or false) {0}", status.IsHealthy));
            Console.WriteLine(string.Format("BMI number is {0}", status.BMINumber));
            Console.WriteLine(string.Format("BMI status is {0}", status.BMIStatus));
            Console.WriteLine(string.Format("Body fat percent is {0}", status.BodyFatPercent.BodyFatPercentNumber));
            Console.WriteLine(string.Format("Body fat percent number is {0}", status.BodyFatPercentStatus));

            Console.WriteLine("It is over.");
            Console.Read();
        }
    }
}
