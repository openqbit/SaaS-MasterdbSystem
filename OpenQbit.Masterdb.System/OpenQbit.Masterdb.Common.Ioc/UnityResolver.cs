using OpenQbit.Masterdb.BusinessService;
using OpenQbit.Masterdb.Common.Model;
using OpenQbit.Masterdb.Common.Utils.Logs;
using OpenQbit.Masterdb.DataAccess.DAL.Contracts;
using OpenQbit.Masterdb.DataAccsess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace OpenQbit.Masterdb.Common.Ioc
{
   public class UnityResolver
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void Register()
        {
            Container.RegisterType<IRepository, Repository>();
            Container.RegisterType<ILogger, LoggerB>();

            Container.RegisterType<Resorce, ResourceManger>();
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
