using Ninject.Modules;
using ReservationManagerApplication.Abstract;
using ReservationManagerApplication.Concrete;
using ReservationManagerApplication.Dao;
using ReservationManagerApplication.Dao.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ITableManager>().To<TableManager>().InSingletonScope();
            Bind<IReservationManager>().To<ReservationManager>().InSingletonScope();
            Bind<ITableDao>().To<TableDao>().InSingletonScope();
            Bind<IReservationDao>().To<ReservationDao>().InSingletonScope();
        }
    }
}
