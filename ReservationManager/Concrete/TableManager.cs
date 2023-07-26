using ReservationManagerApplication.Abstract;
using ReservationManagerApplication.Dao;
using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Concrete
{
    public class TableManager : ITableManager
    {
        private IReservationDao reservationDao;
        private ITableDao tableDao;
        public TableManager(ITableDao tableDao, IReservationDao reservationDao)
        {
            this.tableDao = tableDao;
            this.reservationDao = reservationDao;
        }
        List<Table> ITableManager.GetTables(DateTime date, int guests)
        {
            return tableDao.getAllTables();
        }


        public List<Table> getAvailableTables(DateTime dateTime, int guests)
        {
            List<Table> avaliableTables = tableDao.getAllTables();
            avaliableTables = avaliableTables.FindAll(table => table.Capacity >= guests);

            List<Reservation> reservations = reservationDao.getReservationsByDate(dateTime);
            if (reservations.Count > 0)
            {
                avaliableTables = avaliableTables.FindAll(table =>
        !reservations.Any(reservation => reservation.TableNumber == table.Number));
            }
            return avaliableTables;
        }



    }
}
