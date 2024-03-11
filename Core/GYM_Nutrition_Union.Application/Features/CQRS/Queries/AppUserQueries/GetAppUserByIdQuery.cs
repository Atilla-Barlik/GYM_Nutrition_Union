using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Queries.AppUserQueries
{
	public class GetAppUserByIdQuery
	{
        public int Id { get; set; }

		public GetAppUserByIdQuery(int id)
		{
			Id = id;
		}
	}
}
