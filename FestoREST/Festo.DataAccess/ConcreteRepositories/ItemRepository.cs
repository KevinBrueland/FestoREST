using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
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
    }
}
