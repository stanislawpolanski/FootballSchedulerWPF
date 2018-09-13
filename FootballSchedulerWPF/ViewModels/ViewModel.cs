using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
