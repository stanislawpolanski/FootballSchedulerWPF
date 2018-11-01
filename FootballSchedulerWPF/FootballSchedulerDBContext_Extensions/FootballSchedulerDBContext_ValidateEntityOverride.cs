using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Data.Entity.Validation;

namespace FootballSchedulerWPF
{
    public partial class FootballSchedulerDBContext : DbContext
    {
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //validate League
            if(entityEntry.Entity is Matches)
            {
                if(entityEntry.CurrentValues.GetValue<Nullable<int>>("HomeScore") != null && (entityEntry.CurrentValues.GetValue<int>("HomeScore") > 64 || entityEntry.CurrentValues.GetValue<int>("HomeScore") < 0))
                {
                    List<DbValidationError> validationErrors = new List<DbValidationError>();

                    validationErrors.Add(new DbValidationError("HomeScore", "HomeScore out of range"));

                    return new DbEntityValidationResult(entityEntry, validationErrors);
                }
            }

            if (entityEntry.CurrentValues.GetValue<Nullable<int>>("AwayScore") != null && (entityEntry.CurrentValues.GetValue<int>("AwayScore") > 64 || entityEntry.CurrentValues.GetValue<int>("AwayScore") < 0))
            {
                List<DbValidationError> validationErrors = new List<DbValidationError>();

                validationErrors.Add(new DbValidationError("HomeScore", "HomeScore out of range"));

                return new DbEntityValidationResult(entityEntry, validationErrors);
            }

            return base.ValidateEntity(entityEntry, items);
        }

    }
}
