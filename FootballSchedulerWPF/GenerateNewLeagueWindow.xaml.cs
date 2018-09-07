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

namespace FootballSchedulerWPF
{
    /// <summary>
    /// Interaction logic for GenerateNewLeagueWindow.xaml
    /// </summary>
    public partial class GenerateNewLeagueWindow : Window
    {
        private MainWindow mainWindow;

        public GenerateNewLeagueWindow()
        {
            InitializeComponent();
        }

        public GenerateNewLeagueWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            //sourceTeamsListBox.ItemsSource = null;

            using (FootballSchedulerDBContext context = new FootballSchedulerDBContext())
            {
                context.Teams.Load();
                sourceTeamsListBox.ItemsSource = context.Teams.Local;
            }
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
    }
}
