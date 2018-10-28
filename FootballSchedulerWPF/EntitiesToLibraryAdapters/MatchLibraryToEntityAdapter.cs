using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    class MatchLibraryToEntityAdapter : Matches, IEntitiesToLibraryAdapter
    {
        public void Adapt(object adaptee)
        {
            if (adaptee is FootballSchedulerDLL.AuxiliaryClasses.IMatch match)
            {
                base.HomeTeamId = match.HomeTeam.Id;
                base.AwayTeamId = match.AwayTeam.Id;
                base.LeagueId   = match.LeagueId;
            }
            else
                throw new ArgumentException("Adaptee is not a type of FootballSchedulerWPF.League.");
        }
    }
}
