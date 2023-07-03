namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        //return (MadeBy == user); -- triggering an error on purpose to check error on Test Explorer View
        public bool CanBeCancelledBy(User user) => (user.IsAdmin || MadeBy == user);
        
        
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}