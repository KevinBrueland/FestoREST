using Festo.Common.DataMapperInterfaces;
using Festo.Common.RepositoryInterfaces;
using Festo.DataAccess.ConcreteRepositories;
using Festo.Utility.DataMappers;
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
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderMapper, OrderMapper>(new HierarchicalLifetimeManager());
        }
    }
}