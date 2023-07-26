using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Dao
{
    public interface ITableDao
    {
         List<Table> getAllTables();
    }
}
