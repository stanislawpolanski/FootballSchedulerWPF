namespace FootballSchedulerWPF.ViewModels
{
    public abstract class ViewModel
    {
        protected FootballSchedulerDBContext Context;

        public ViewModel()
        {
            this.Context = new FootballSchedulerDBContext();
        }
    }
}
