using ReservationManagerApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Dao
{
    public interface IReservationDao
    {
         List<Reservation> getAllReservations();
         List<Reservation> getReservationsByDate(DateTime dateTime);
         Reservation saveReservation(Reservation reservation);
    }
}
