using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using Festo.Utility.RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.DataAccess.ConcreteRepositories
{
    public class ItemTrackerRepository : Repository<ITEMTRACKER>, IItemTrackerRepository
    {
        public ItemTrackerRepository(FestoContext context) : base(context)
        {
            
        }

        public FestoContext FestoContext
        {
            get { return Context as FestoContext; }
        }

        public ITEMTRACKER GetItemTrackerByItemId(int itemId)
        {
            return Context.Set<ITEMTRACKER>().FirstOrDefault(i => (i.ItemID == itemId));
        }

        public ITEMTRACKER GetSingleItemTrackerByOrderAndItemId(int orderId, int itemId)
        {
            return Context.Set<ITEMTRACKER>().FirstOrDefault(it => (it.OrderID == orderId) && (it.ItemID == itemId));
        }

        public object UpdateItemTracker(ITEMTRACKER itemTracker)
        {
            try
            {

                // you can only update when the resource already exists for this id

                var existingItemTracker = GetSingleItemTrackerByOrderAndItemId(itemTracker.OrderID, itemTracker.ItemID);

                if (existingItemTracker == null)
                {
                    return new RepositoryActionResult<ITEMTRACKER>(itemTracker, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingItemTracker).State = EntityState.Detached;

                // attach & save
                Context.Set<ITEMTRACKER>().Attach(itemTracker);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(itemTracker).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<ITEMTRACKER>(itemTracker, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<ITEMTRACKER>(itemTracker, RepositoryActionStatus.NothingModified);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ITEMTRACKER>(null, RepositoryActionStatus.Error, ex);
            }

        }

        object IItemTrackerRepository.UpdateItemTracker(ITEMTRACKER itemTracker)
        {
            throw new NotImplementedException();
        }
    }
}
