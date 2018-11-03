using System;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    class MatchEntityToLibraryAdapter : FootballSchedulerDLL.AuxiliaryClasses.Match, IEntitiesToLibraryAdapter
    {
        public void Adapt(object adaptee)
        {
            if (adaptee is Matches match)
            {
                this.Id = match.Id;
                this.LeagueId = match.LeagueId;
                this.TimeOfPlay = match.TimeOfPlay;
            }
            else
                throw new ArgumentException("Adaptee is not a type of FootballSchedulerWPF.Matches.");
        }
    }
}
