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
            System.Windows.Data.CollectionViewSource leaguesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("leaguesViewSource")));
            context.Leagues.Load();
            leaguesViewSource.Source = context.Leagues.Local;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void showStandingsButton_Click(object sender, RoutedEventArgs e)
        {
            StandingsViewWindow standingsWindow = new StandingsViewWindow(this);
            standingsWindow.Show();
        }
    }
}
