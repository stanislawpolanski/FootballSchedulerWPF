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
            Leagues selectedLeague = (Leagues)mw.nameComboBox.SelectedItem;
            using (FootballSchedulerDBContext context = new FootballSchedulerDBContext())
            {

            }
        }
    }
}
