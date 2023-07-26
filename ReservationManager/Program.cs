using ReservationManagerApplication.Abstract;
using ReservationManagerApplication.Dao;
using ReservationManagerApplication.Model;
using ReservationManagerApplication.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            Console.WriteLine("Reservation Manager Application");

            DI.Initialize();
            ITableManager tableManager = DI.Create<ITableManager>();

            IReservationManager reservationManager = DI.Create<IReservationManager>();
            reservationManager.MakeReservation("Mazı", DateTime.Now, 5);
            reservationManager.MakeReservation("Cihan", new DateTime(2023, 7, 22, 18, 0, 0), 5);

            IReservationDao reservationDao = DI.Create<IReservationDao>();
            List<Reservation> reservations = reservationDao.getAllReservations();
            Console.WriteLine();
        }
    }
}
