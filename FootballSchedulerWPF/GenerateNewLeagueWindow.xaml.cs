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
            //TODO parsing year of start
            

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
        }
    }
}
