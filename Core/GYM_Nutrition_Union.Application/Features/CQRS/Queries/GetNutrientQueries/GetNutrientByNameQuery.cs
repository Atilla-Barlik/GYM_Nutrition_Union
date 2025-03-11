using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientQueries
{
    public class GetNutrientByNameQuery
    {
        public string Name { get; }

        public GetNutrientByNameQuery(string name)
        {
            Name = name;
        }
    }
}
