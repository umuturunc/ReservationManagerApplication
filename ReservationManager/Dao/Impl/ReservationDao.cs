using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Dao.Impl
{
    internal class ReservationDao : IReservationDao
    {
        public List<Reservation> getAllReservations()
        {
            return DataBase.getReservations();
        }

        public List<Reservation> getReservationsByDate(DateTime dateTime)
        {
            return DataBase.getReservationsByDate(dateTime);
        }

        public Reservation saveReservation(Reservation reservation)
        {
            DataBase.addReservation(reservation);
            Console.WriteLine(reservation);
            return reservation;
        }
    }
}
