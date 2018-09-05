using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    public interface IEntitiesToLibraryAdapter
    {
        void Adapt(object adaptee);
    }
}
