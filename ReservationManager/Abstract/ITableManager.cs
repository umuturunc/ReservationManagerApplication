using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Abstract
{
    public interface ITableManager
    {
        List<Table> GetTables(DateTime date, int guests);
        List<Table> getAvailableTables(DateTime dateTime, int guests);
    }
}
