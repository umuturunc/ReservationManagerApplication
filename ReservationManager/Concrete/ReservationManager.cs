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
    public class ReservationManager : IReservationManager
    {
        ITableManager _tableManager;
        IReservationDao _reservationDao;
        public ReservationManager(ITableManager tableManager, IReservationDao reservationDao)
        {
            _tableManager = tableManager;
            _reservationDao = reservationDao;
        }
        public void initialize()
        {

        }

        public void MakeReservation(string name, DateTime date, int guests)
        {

            if (date.Hour > Constants.Constants.ReservationHourMaxLimit || date.Hour < Constants.Constants.ReservationHourMinLimit)
            {
                Console.WriteLine("Üzgünüz, restoranımız bu saatler arasında kapalıdır :" + Constants.Constants.ReservationHourMaxLimit + " - " + Constants.Constants.ReservationHourMinLimit);
                return;
            }
            List<Table> tables = _tableManager.getAvailableTables(date, guests);
            if (tables == null || tables.Count == 0)
            {
                Console.WriteLine("Üzgünüz, uygun masa bulunamadı.");
                return;
            }
            List<Reservation> reservations = _reservationDao.getReservationsByDate(date);


            tables.Sort((t1, t2) => t1.Capacity - t2.Capacity); // küçükten büyüğe
            var table = tables[0];
            var reservation = new Reservation
            {
                CustomerFullName = name,
                ReservationDate = date,
                NumberOfGuests = guests,
                TableNumber = table.Number
            };
            _reservationDao.saveReservation(reservation);

        }
    }
}
