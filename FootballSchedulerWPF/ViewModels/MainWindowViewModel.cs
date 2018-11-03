using System.Collections.ObjectModel;
using System.Data.Entity;

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
