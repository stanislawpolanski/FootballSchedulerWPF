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
using FootballSchedulerWPF.ViewModels;

namespace FootballSchedulerWPF
{
    /// <summary>
    /// Interaction logic for StandingsViewWindow.xaml
    /// </summary>
    public partial class StandingsViewWindow : Window
    {
        private MainWindow mainWindow;
        private StandingsViewViewModel viewModel;

        public StandingsViewWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mainWindow = mw;
            this.viewModel = new StandingsViewViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Leagues selectedLeague = (Leagues)this.mainWindow.nameComboBox.SelectedItem;

            System.Windows.Data.CollectionViewSource getLeagueStandingsByLeagueId_ResultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("getLeagueStandingsByLeagueId_ResultViewSource")));

            getLeagueStandingsByLeagueId_ResultViewSource.Source = this.viewModel.ReturnData(selectedLeague.Id);

            System.Windows.Data.CollectionViewSource districtsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("districtsViewSource")));
        }
    }
}
