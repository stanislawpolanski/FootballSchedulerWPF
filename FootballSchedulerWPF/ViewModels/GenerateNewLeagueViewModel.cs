using FootballSchedulerDLL;
using FootballSchedulerDLL.AuxiliaryClasses;
using FootballSchedulerWPF.EntitiesToLibraryAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Controls;

namespace FootballSchedulerWPF.ViewModels
{
    public class GenerateNewLeagueViewModel : ViewModel
    {
        public string NewLeagueName { get; internal set; }
        public int NewLeagueYearOfStart { get; internal set; }
        public ItemCollection TeamsForNewLeague { get; internal set; }

        public GenerateNewLeagueViewModel()
        {
            this.Context = new FootballSchedulerDBContext();
        }

        public ObservableCollection<Teams> ReturnData()
        {
            Context.Teams.Load();
            return Context.Teams.Local;
        }

        public bool GenerateSchedule()
        {
            Leagues newLeagueEntity = new Leagues
            {
                Name = this.NewLeagueName
            };

            DateTime yearOfStart = new DateTime(this.NewLeagueYearOfStart, 1, 1);

            LeagueEntityToLibraryAdapter newLeagueAdapter = new LeagueEntityToLibraryAdapter();
            newLeagueAdapter.Adapt(newLeagueEntity);

            RoundRobinScheduler scheduler = new RoundRobinScheduler();

            scheduler.LoadLeague(newLeagueAdapter);

            List<ITeam> listOfTeamsAdapter = new List<ITeam>();

            foreach (Teams team in this.TeamsForNewLeague)
            {
                TeamEntityToLibraryAdapter teamAdapter = new TeamEntityToLibraryAdapter();
                teamAdapter.Adapt(team);
                listOfTeamsAdapter.Add(teamAdapter);
            }

            scheduler.LoadTeams(listOfTeamsAdapter);

            scheduler.YearOfStart = yearOfStart;

            scheduler.GenerateSchedule();

            List<IMatch> listOfMatchesFromAlgorithm = scheduler.GetSchedule();

            List<Matches> listOfMatchesEntities = new List<Matches>();

            foreach (IMatch match in listOfMatchesFromAlgorithm)
            {
                Matches m = new Matches()
                {
                    TimeOfPlay = match.TimeOfPlay,
                    HomeTeamId = match.HomeTeam.Id,
                    AwayTeamId = match.AwayTeam.Id,
                };

                Context.Matches.Add(m);
            }
            Context.Leagues.Add(newLeagueEntity);
            Context.SaveChanges();

            return true;
        }


        internal bool TrySetYearInput(string text)
        {
            if (text == String.Empty)
            {
                return false;
            }

            int yearOfStartNumberFromTextBox;
            if (!int.TryParse(text, out yearOfStartNumberFromTextBox))
            {
                return false;
            }

            this.NewLeagueYearOfStart = yearOfStartNumberFromTextBox;
            return true;
        }

        internal bool CheckNameInput(string text)
        {
            if (text == String.Empty)
                return false;

            return true;
        }
    }
}
