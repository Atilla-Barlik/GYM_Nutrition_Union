using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserBodyMassIndexQueries
{
	public class GetAppUserBodyMassIndexByIdQuery
	{
        public int Id { get; set; }

		public GetAppUserBodyMassIndexByIdQuery(int id)
		{
			Id = id;
		}
	}
}
