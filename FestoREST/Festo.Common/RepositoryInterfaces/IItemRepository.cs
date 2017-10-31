using Festo.DataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festo.Common.RepositoryInterfaces
{
    public interface IItemRepository : IRepository<ITEM>
    {
        IEnumerable<ITEM> GetAllItemsByOrderId(int orderId);

        IEnumerable<ITEM> GetAllItems();

        ITEM GetSingleItemById(int itemId);

        object UpdateItem(ITEM item);
    }
}
