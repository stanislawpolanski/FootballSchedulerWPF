﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballSchedulerWPF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FootballSchedulerDBContext : DbContext
    {
        public FootballSchedulerDBContext()
            : base("name=FootballSchedulerDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
    
        [DbFunction("FootballSchedulerDBContext", "GetLeagueStandingsByLeagueId")]
        public virtual IQueryable<GetLeagueStandingsByLeagueId_Result> GetLeagueStandingsByLeagueId(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetLeagueStandingsByLeagueId_Result>("[FootballSchedulerDBContext].[GetLeagueStandingsByLeagueId](@LeagueId)", leagueIdParameter);
        }
    
        [DbFunction("FootballSchedulerDBContext", "GetMatchesByLeagueId")]
        public virtual IQueryable<GetMatchesByLeagueId_Result> GetMatchesByLeagueId(Nullable<int> leagueId)
        {
            var leagueIdParameter = leagueId.HasValue ?
                new ObjectParameter("LeagueId", leagueId) :
                new ObjectParameter("LeagueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetMatchesByLeagueId_Result>("[FootballSchedulerDBContext].[GetMatchesByLeagueId](@LeagueId)", leagueIdParameter);
        }
    }
}
