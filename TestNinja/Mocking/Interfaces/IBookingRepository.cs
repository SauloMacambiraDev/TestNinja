using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking.Interfaces
{
    public interface IBookingRepository
    {
        /// <summary>
        /// Pursuit all bookings in the database by applying some condition.
        /// </summary>
        /// <param name="condition">Condition to pursuit bookings.</param>
        /// <returns>An IQueryable object with the list of books returned from database.</returns>
        IQueryable<Booking> GetAll(Expression<Func<Booking, bool>> condition);

        IQueryable<Booking> GetActiveBookingById(Booking booking);
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);

        Booking GetActiveOverlappedBooking(Booking booking);
    }
}
