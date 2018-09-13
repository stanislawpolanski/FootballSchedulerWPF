using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSchedulerWPF.ViewModels
{
    public class StandingsViewViewModel : ViewModel
    {
        public StandingsViewViewModel() : base()
        {

        }

        public IQueryable<GetLeagueStandingsByLeagueId_Result> ReturnData(int selectedLeagueId)
        {
            return Context.GetLeagueStandingsByLeagueId(selectedLeagueId).OrderByDescending(x => x.Points).ThenByDescending(x => x.GoalsDifference).ThenByDescending(x => x.GoalsFor).ThenByDescending(x => x.Played).ThenByDescending(x => x.TeamName);
        }
    }
}
