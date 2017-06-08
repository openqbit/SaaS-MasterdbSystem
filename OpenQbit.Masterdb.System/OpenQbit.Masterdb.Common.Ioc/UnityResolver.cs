using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Common.Ioc
{
   public class UnityResolver
    {
        private static readonly IUnityContainer Container = new EntityContainer();

        public static void Register()
        {
            Container.RegisterType<IRepository, Repository>();
            Container.RegisterType<ILogger, LoggerB>();

            Container.RegisterType<Res, InvoiceManger>();
        }

        public static T Resolve<T>()
        {
            T defaultT = default(T);
            var resolved = Container.Resolve<T>();
            return (resolved == null) ? defaultT : resolved;
        }

        public static IUnityContainer GetContainer()
        {
            return Container;
        }
    }
}
