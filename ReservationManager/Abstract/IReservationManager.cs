using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication
{
    internal interface IReservationManager
    {
        void MakeReservation(string name, DateTime date, int guests);
    }
}
