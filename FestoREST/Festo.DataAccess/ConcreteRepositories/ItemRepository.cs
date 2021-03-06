﻿using Festo.Common.Enums;
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
    public class ItemRepository : Repository<ITEM>, IItemRepository
    {
        public ItemRepository(FestoContext context) : base(context)
        {

        }

        public FestoContext FestoContext
        {
            get { return Context as FestoContext; }
        }

        public IEnumerable<ITEM> GetAllItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITEM> GetAllItems()
        {
            return Context.Set<ITEM>().ToList();
        }

        public ITEM GetSingleItemById(int itemId)
        {
            return Context.Set<ITEM>().FirstOrDefault(i => i.ItemID == itemId);
        }

        public object UpdateItem(ITEM item)
        {
            try
            {

                var existingItem = Context.Set<ITEM>().FirstOrDefault(i => i.ItemID == item.ItemID);

                if (existingItem == null)
                {
                    return new RepositoryActionResult<ITEM>(item, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingItem).State = EntityState.Detached;

                // attach & save
                Context.Set<ITEM>().Attach(item);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(item).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<ITEM>(item, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<ITEM>(item, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ITEM>(null, RepositoryActionStatus.Error, ex);
            }

        }
    }
}
