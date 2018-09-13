using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace FootballSchedulerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel() : base()
        {
            this.Context.Leagues.Load();
        }

        public ObservableCollection<Leagues> ReturnData()
        {
            return Context.Leagues.Local;
        }

        internal void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
