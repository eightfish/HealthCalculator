using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator
{
    class HealthStatus
    {
        public double BMINumber { get; private set; }
        public BodyFatPercent BodyFatPercent { get; private set; }
        
        public BMIStatus BMIStatus
        {
            get
            {
                BMIStatus status = BMIStatus.Normal;
                if (this.BMINumber < 18.5)
                {
                    status = BMIStatus.Light;
                }
                else if (this.BMINumber >= 18.5 && this.BMINumber < 22)
                {
                    status = BMIStatus.Normal;
                }
                else if (this.BMINumber >= 22 && this.BMINumber < 24)
                {
                    status = BMIStatus.Best;
                }
                else if (this.BMINumber >= 25 && this.BMINumber < 30)
                {
                    status = BMIStatus.Fat;
                }
                else if (this.BMINumber >= 30 && this.BMINumber < 40)
                {
                    status = BMIStatus.VeryFat;
                }
                else if (this.BMINumber >= 40)
                {
                    status = BMIStatus.ExtremeFat;
                }

                return status;
            }
        }

        public BodyFatPercentStatus BodyFatPercentStatus
        {
            get
            {
                BodyFatPercentStatus status = BodyFatPercentStatus.Normal;
                if ((this.BodyFatPercent.BodyFatPercentNumber <= 5 && this.BodyFatPercent.PersonSex == Sex.male)
                    || this.BodyFatPercent.BodyFatPercentNumber <= 15 && this.BodyFatPercent.PersonSex == Sex.female)
                {
                    status = BodyFatPercentStatus.Thin;
                }
                else if ((this.BodyFatPercent.BodyFatPercentNumber >= 15 && this.BodyFatPercent.BodyFatPercentNumber < 18 && this.BodyFatPercent.PersonSex == Sex.male)
                    || (this.BodyFatPercent.BodyFatPercentNumber >= 25 && this.BodyFatPercent.BodyFatPercentNumber < 30 && this.BodyFatPercent.PersonSex == Sex.female))
                {
                    status = BodyFatPercentStatus.Normal;
                }
                else if ((this.BodyFatPercent.BodyFatPercentNumber >= 25 && this.BodyFatPercent.PersonSex == Sex.male)
                    || (this.BodyFatPercent.BodyFatPercentNumber >= 30 && this.BodyFatPercent.PersonSex == Sex.female))
                {
                    status = BodyFatPercentStatus.Fat;
                }

                return status;
            }
        }

        public bool IsHealthy
        {
            get
            {
                bool isHealthy = false;

                if ((this.BodyFatPercentStatus == BodyFatPercentStatus.Normal) 
                    ||(this.BMIStatus == BMIStatus.Normal || this.BMIStatus == BMIStatus.Best))
                {
                    return true;
                }

                return isHealthy;
            }
        }

        public static Tuple<double, double> BestBMINumberRange = new Tuple<double, double>(22, 23);
        public static Tuple<double, double> MaleBestBodyFatPercentNumberRange = new Tuple<double, double>(15, 17);
        public static Tuple<double, double> FemaleBestBodyFatPercentNumberRange = new Tuple<double, double>(25, 29);

        public HealthStatus(double BMINumber, BodyFatPercent bodyFatPercent)
        {
            this.BMINumber = BMINumber;
            this.BodyFatPercent = bodyFatPercent;
        }
    }
}
