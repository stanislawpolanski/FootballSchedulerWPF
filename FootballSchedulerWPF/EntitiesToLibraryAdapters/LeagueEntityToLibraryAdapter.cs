using System;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    public class LeagueEntityToLibraryAdapter : FootballSchedulerDLL.AuxiliaryClasses.League, IEntitiesToLibraryAdapter
    {
        public void Adapt(object adaptee)
        {
            if (adaptee is Leagues league)
            {
                this.Id = league.Id;
                this.Name = league.Name;
            }
            else
                throw new ArgumentException("Adaptee is not a type of FootballSchedulerWPF.League.");
        }
    }
}
