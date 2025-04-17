using GYM_Nurition.Domain.Dtos;
using GYM_Nurition.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.GetNutrientTotalsQueries
{
    public class GetNutrientTotalsQuery 
    {
        public int appUserId { get; set; }


        public GetNutrientTotalsQuery(int AppUserId) 
        {
            AppUserId = appUserId;
        }
    }
}
