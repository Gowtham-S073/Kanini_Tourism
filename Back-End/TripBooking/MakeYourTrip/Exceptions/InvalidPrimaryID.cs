namespace TripBooking.Exceptions
{
    public class InvalidPrimaryID : Exception
    {
        string message;
        public InvalidPrimaryID()
        {
            message = "Primary ID should be Empty";
        }
        public InvalidPrimaryID(string message)
        {
            this.message = message;
        }
        public override string Message
        {
            get { return message; }
        }
    }
}
