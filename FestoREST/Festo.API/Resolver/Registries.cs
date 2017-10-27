using Festo.Common.DataMapperInterfaces;
using Festo.Common.RepositoryInterfaces;
using Festo.Common.UtilityInterfaces;
using Festo.DataAccess.ConcreteRepositories;
using Festo.Utility.DataMappers;
using Festo.Utility.RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace Festo.API.Resolver
{
    public static class Registries
    {
        public static void LoadRegistries(this UnityContainer container)
        {
            //map dependencies here
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderMapper, OrderMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemMapper, ItemMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderTrackerMapper, OrderTrackerMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemTrackerMapper, ItemTrackerMapper>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepositoryActionResult<>), typeof(RepositoryActionResult<>));
        }
    }
}