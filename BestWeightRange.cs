using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator
{
    class BestWeightRange
    {
        public Tuple<double, double> WeightRangeOfBMI { get; set; }
        public Tuple<double, double> WeightRangeOfBodyFatPercent { get; set; }
    }
}
