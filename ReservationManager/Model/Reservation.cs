using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagerApplication.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableNumber { get; set; }

        public override string ToString()
        {
            return String.Format("Reservation: CustomerName:{0} ReservationDate:{1} NumberOfGuests:{2} TableNumber:{3} ", CustomerFullName, ReservationDate, NumberOfGuests, TableNumber);
        }
    }
}
