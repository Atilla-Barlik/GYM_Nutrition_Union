using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.NutrientCommands
{
    public class RemoveNutrientCommand
    {
        public int Id { get; set; }

        public RemoveNutrientCommand(int id)
        {
            Id = id;
        }
    }
}
