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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FootballSchedulerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FootballSchedulerDBContext context = new FootballSchedulerDBContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource getMatchesByLeagueId_ResultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("getMatchesByLeagueId_ResultViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // getMatchesByLeagueId_ResultViewSource.Source = [generic data source]


            System.Windows.Data.CollectionViewSource leaguesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("leaguesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // leaguesViewSource.Source = [generic data source]
            this.context.Leagues.Load();
            leaguesViewSource.Source = this.context.Leagues.Local.ToList();


            System.Windows.Data.CollectionViewSource matchesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("matchesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // matchesViewSource.Source = [generic data source]
            context.Matches.Load();
            matchesViewSource.Source = context.Matches.Local;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
