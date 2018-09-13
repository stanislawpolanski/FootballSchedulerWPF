using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FootballSchedulerDLL;
using FootballSchedulerDLL.AuxiliaryClasses;
using FootballSchedulerWPF.EntitiesToLibraryAdapters;

namespace FootballSchedulerWPF
{
    /// <summary>
    /// Interaction logic for GenerateNewLeagueWindow.xaml
    /// </summary>
    public partial class GenerateNewLeagueWindow : Window
    {
        private MainWindow mainWindow;
        private FootballSchedulerDBContext Context;

        public GenerateNewLeagueWindow()
        {
            InitializeComponent();
        }

        public GenerateNewLeagueWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            Context = new FootballSchedulerDBContext();
            Context.Teams.Load();
            sourceTeamsListBox.ItemsSource = Context.Teams.Local;
        }

        private void copyTeamToNewLeague_Click(object sender, RoutedEventArgs e)
        {
            if (targetTeamsListBox.Items.Contains(sourceTeamsListBox.SelectedItem))
            {
                MessageBox.Show("Team already copied.");
                return;
            }
            targetTeamsListBox.Items.Add(sourceTeamsListBox.SelectedItem);
        }

        private void removeTeamFromNewLeague_Click(object sender, RoutedEventArgs e)
        {
            targetTeamsListBox.Items.Remove(targetTeamsListBox.SelectedItem);
        }

        private void generateLeagueButton_Click(object sender, RoutedEventArgs e)
        {
            //todo create viewmodel instead - then test it console
            if (newLeagueNameTextBox.Text == null || newLeagueNameTextBox.Text == String.Empty)
            {
                MessageBox.Show("No league's name.");
                return;
            }
            if (newLeagueYearOfStartTextBox.Text == null || newLeagueYearOfStartTextBox.Text == String.Empty)
            {
                MessageBox.Show("No year of start.");
                return;
            }

            Leagues newLeagueEntity = new Leagues
            {
                Name = newLeagueNameTextBox.Text
            };
            //parsing year of start
            int yearOfStartNumberFromTextBox;
            if(!int.TryParse(newLeagueYearOfStartTextBox.Text, out yearOfStartNumberFromTextBox))
            { 
                MessageBox.Show("Invalid year of start.");
                return;
            }

            DateTime yearOfStart = new DateTime(yearOfStartNumberFromTextBox, 1, 1);

            LeagueEntityToLibraryAdapter newLeagueAdapter = new LeagueEntityToLibraryAdapter();
            newLeagueAdapter.Adapt(newLeagueEntity);

            RoundRobinScheduler scheduler = new RoundRobinScheduler();

            scheduler.LoadLeague(newLeagueAdapter);

            List<ITeam> listOfTeamsAdapter = new List<ITeam>();

            foreach(Teams team in targetTeamsListBox.Items)
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

            Matches m = new Matches();
            m.HomeTeamId = 3;
            m.AwayTeamId = 5;
            m.LeagueId = 15;
            Context.Matches.Add(m);
            /*
            foreach(IMatch match in listOfMatchesFromAlgorithm)
            {
                MatchLibraryToEntityAdapter matchAdapter = new MatchLibraryToEntityAdapter();
                matchAdapter.Adapt(match);
                matchAdapter.LeagueId = newLeagueEntity.Id;

                Matches adaptedMatch = (Matches)matchAdapter;

                Context.Matches.Add(adaptedMatch);
            }
            Context.Leagues.Add(newLeagueEntity);*/
            Context.SaveChanges();
        }
    }
}
