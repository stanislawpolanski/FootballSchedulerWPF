using System;
using System.Collections.Generic;
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
    /// Interaction logic for StandingsViewWindow.xaml
    /// </summary>
    public partial class StandingsViewWindow : Window
    {
        private MainWindow mainWindow;
        public StandingsViewWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mainWindow = mw;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Leagues selectedLeague = (Leagues)this.mainWindow.nameComboBox.SelectedItem;
            using (FootballSchedulerDBContext context = new FootballSchedulerDBContext())
            {
                System.Windows.Data.CollectionViewSource getLeagueStandingsByLeagueId_ResultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("getLeagueStandingsByLeagueId_ResultViewSource")));
                // Load data by setting the CollectionViewSource.Source property:
                // getLeagueStandingsByLeagueId_ResultViewSource.Source = [generic data source]
                getLeagueStandingsByLeagueId_ResultViewSource.Source = context.GetLeagueStandingsByLeagueId(selectedLeague.Id).OrderByDescending(x => x.Points).ThenByDescending(x => x.GoalsDifference).ThenByDescending(x => x.GoalsFor).ThenByDescending(x => x.Played).ThenByDescending(x => x.TeamName);
            }
            System.Windows.Data.CollectionViewSource districtsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("districtsViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // districtsViewSource.Source = [generic data source]
        }
    }
}
