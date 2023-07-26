using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Dao.Impl
{
    public class TableDao : ITableDao
    {
        public List<Table> getAllTables()
        {
            return DataBase.getDiningTables();
        }

    }
}
