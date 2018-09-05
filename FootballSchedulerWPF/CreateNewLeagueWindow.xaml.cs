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
    /// Interaction logic for CreateNewLeagueWindow.xaml
    /// </summary>
    public partial class CreateNewLeagueWindow : Window
    {
        private MainWindow mainWindow;

        public CreateNewLeagueWindow()
        {
            InitializeComponent();
        }

        public CreateNewLeagueWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
    }
}
