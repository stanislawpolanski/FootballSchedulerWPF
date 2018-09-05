using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    public class EntitiesAdaptersFactory
    {
        protected Dictionary<Type, Type> KeysToValues;

        public EntitiesAdaptersFactory()
        {
            //todo register basic types
            throw new NotImplementedException();
        }

        public void Register()
        {
            //todo registering
            throw new NotImplementedException();
        }

        public IEntitiesToLibraryAdapter Initialize()
        {
            //todo initializing
            throw new NotImplementedException();
        }
    }
}
