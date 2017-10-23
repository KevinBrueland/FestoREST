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
    public class OrderTrackerRepository : Repository<ORDERTRACKER>, IOrderTrackerRepository
    {
        public OrderTrackerRepository(FestoContext context) : base(context)
        {

        }

        public FestoContext FestoContext
        {
            get { return Context as FestoContext; }
        }

        public ORDERTRACKER GetSingleOrderTrackerByOrderId(int orderId)
        {
            return Context.Set<ORDERTRACKER>().FirstOrDefault(ot => ot.OrderID == orderId);
        }

        public object UpdateOrderTracker(ORDERTRACKER orderTracker)
        {
            try
            {

                // you can only update when the resource already exists for this id

                var existingOrderTracker = GetSingleOrderTrackerByOrderId(orderTracker.OrderID);

                if (existingOrderTracker == null)
                {
                    return new RepositoryActionResult<ORDERTRACKER>(orderTracker, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingOrderTracker).State = EntityState.Detached;

                // attach & save
                Context.Set<ORDERTRACKER>().Attach(orderTracker);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(orderTracker).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<ORDERTRACKER>(orderTracker, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<ORDERTRACKER>(orderTracker, RepositoryActionStatus.NothingModified);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ORDERTRACKER>(null, RepositoryActionStatus.Error, ex);
            }

        }
    }
}
