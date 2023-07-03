using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public BookingRepository(UnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork ?? new UnitOfWork();
        }

        public IQueryable<Booking> GetActiveBookingById(Booking booking)
        {
            return _unitOfWork.Query<Booking>().Where(b => b.Id != booking.Id && b.Status != "Cancelled");
        }
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var bookings = _unitOfWork.Query<Booking>().Where(b => b.Id != excludedBookingId && b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != excludedBookingId);
            }

            return bookings;
        
        }
            
        public Booking GetActiveOverlappedBooking(Booking booking)
        {
            var bookings = _unitOfWork.Query<Booking>().Where(b => b.Id != booking.Id && b.Status != "Cancelled");

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate >= b.ArrivalDate
                        && booking.ArrivalDate < b.DepartureDate
                        || booking.DepartureDate > b.ArrivalDate
                        && booking.DepartureDate <= b.DepartureDate);

            return overlappingBooking;
        }

        public IQueryable<Booking> GetAll(Expression<Func<Booking, bool>> condition)
        {
            return _unitOfWork.Query<Booking>().Where(condition);
        }

        
    
    }
}
