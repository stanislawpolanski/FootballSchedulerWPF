using System;
using System.Collections.Generic;

namespace FootballSchedulerWPF.EntitiesToLibraryAdapters
{
    public class FactoryEntitiesToAdapters
    {
        protected Dictionary<Type, Type> KeysToValues = new Dictionary<Type, Type>();

        public FactoryEntitiesToAdapters()
        {
            this.Register(typeof(Leagues), typeof(LeagueEntityToLibraryAdapter));
            this.Register(typeof(Matches), typeof(MatchEntityToLibraryAdapter));
            this.Register(typeof(Teams), typeof(TeamEntityToLibraryAdapter));
        }

        /// <summary>
        /// Registers key and value.
        /// </summary>
        /// <param name="Key">Must be IEntitiesToLibraryAdapter, otherwise throws ArgumentException.</param>
        /// <param name="Value"></param>
        public void Register(Type Key, Type Value)
        {
            if (Value is IEntitiesToLibraryAdapter)
                this.KeysToValues.Add(Key, Value);
            else
                throw new ArgumentException();
        }

        public object Initialize(Type Key)
        {
            return Activator.CreateInstance(this.KeysToValues[Key]);
        }
    }
}
