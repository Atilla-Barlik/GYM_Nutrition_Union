using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.NutrientCommands
{
    public class UpdateNutrientCommand
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String image { get; set; }
        public int kcal { get; set; }
        public decimal carbonhydrate { get; set; }
        public decimal protein { get; set; }
        public decimal fat { get; set; }
        public decimal sugar { get; set; }
        public decimal fiber { get; set; }
        public decimal cholestrol { get; set; }
        public decimal sodium { get; set; }
        public decimal potassium { get; set; }
        public decimal calcium { get; set; }
        public decimal vitamin_A { get; set; }
        public decimal vitamin_C { get; set; }
        public decimal iron { get; set; }
    }
}
