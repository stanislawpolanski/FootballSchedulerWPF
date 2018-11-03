using System;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    class TeamEntityToLibraryAdapter : FootballSchedulerDLL.AuxiliaryClasses.Team, IEntitiesToLibraryAdapter
    {
        public void Adapt(object adaptee)
        {
            if (adaptee is Teams team)
            {
                this.DistrictId = team.DistrictId;
                this.Id = team.Id;
                this.Name = team.Name;
            }
            else
                throw new ArgumentException();
        }
    }
}
