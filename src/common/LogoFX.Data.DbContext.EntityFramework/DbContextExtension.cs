using System;
using System.Data.Entity;
using LogoFX.Data.Entities;

namespace LogoFX.Data.DbContext.EntityFramework
{
    public static class DbContextExtension
    {
        public static void ApplyStateChanges(this System.Data.Entity.DbContext dbContext)
        {
            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                var entityState = dbEntityEntry.Entity as IObjectState;
                if (entityState == null)
                    throw new InvalidCastException(
                        "All entities must implement " +
                        "the IObjectState interface, this interface " +
                        "must be implemented so each entities state" +
                        "can explicitly determined when updating graphs.");

                dbEntityEntry.State = ConvertState(entityState.State);
            }
        }

        private static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}