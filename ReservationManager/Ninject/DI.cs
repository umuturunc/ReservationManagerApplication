using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Ninject
{
    static class DI
    {
        static StandardKernel _Kernel;
        static public void Initialize()
        {
            _Kernel = new StandardKernel();
            _Kernel.Load(Assembly.GetExecutingAssembly());
        }

        static public T Create<T>()
        {
            return _Kernel.Get<T>();
        }
    }
}
