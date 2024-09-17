using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientQueries
{
    public class GetNutrientByIdQuery
    {
        public int Id { get; set; }

        public GetNutrientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
