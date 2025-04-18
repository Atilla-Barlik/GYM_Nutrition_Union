using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nurition.Domain.Entities
{
    public class DailyMacro
    {
        public int DailyMacroId { get; set; }
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public DateOnly Date { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
