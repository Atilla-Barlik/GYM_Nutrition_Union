using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
	public class AppUserBodyMassIndex
	{
        public int AppUserBodyMassIndexId { get; set; }
        public decimal BodyMassIndex { get; set; }
        public decimal LeanBodyMass { get; set; }
        public decimal BodyFatPercentage { get; set; }
        public decimal BasalMetabolicRate { get; set; }
        public AppUserDetail AppUserDetail { get; set; }
        public int AppUserDetailId { get; set; }
    }
}
