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
using FootballSchedulerWPF.ViewModels;

namespace FootballSchedulerWPF
{
    /// <summary>
    /// Interaction logic for GenerateNewLeagueWindow.xaml
    /// </summary>
    public partial class GenerateNewLeagueWindow : Window
    {
        private MainWindow mainWindow;
        private GenerateNewLeagueViewModel viewModel;

        public GenerateNewLeagueWindow()
        {
            InitializeComponent();
        }

        public GenerateNewLeagueWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.viewModel = new GenerateNewLeagueViewModel();

            sourceTeamsListBox.ItemsSource = viewModel.ReturnData();
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
            //todo catch-try block
            if (viewModel.CheckNameInput(newLeagueNameTextBox.Text))
                viewModel.NewLeagueName = newLeagueNameTextBox.Text;
            else
                throw new ArgumentException();

            if (!viewModel.TrySetYearInput(newLeagueYearOfStartTextBox.Text))
                throw new ArgumentException("Year incorrect.");

            viewModel.TeamsForNewLeague = targetTeamsListBox.Items;

            bool scheduleGenerated = viewModel.GenerateSchedule();

            if (scheduleGenerated)
                MessageBox.Show("League sucessfully generated.");
            else
                MessageBox.Show("League not generated.");
        }
    }
}
