using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Interfaces.StatisticsInterfaces
{
	public interface IStatisticsRepository
	{
		decimal GetAvgAllTimeConsumeKcal();
		decimal GetAvgAllTimeConsumeProtein();
		decimal GetAvgAllTimeConsumeCarbohydrat();
		decimal GetAvgAllTimeConsumeFat();
		decimal GetAvgAllTimeBurnedKcal();
		string GetMostUsedExerciseEquipment();
		string GetMostEatenFood();
	}
}
