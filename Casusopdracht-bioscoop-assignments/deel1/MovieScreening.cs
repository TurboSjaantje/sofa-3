namespace deel1
{
    public class MovieScreening (DateTime dateAndTime, double pricePerSeat, Movie movie)
    {
        private readonly DateTime _dateAndTime = dateAndTime;
        private readonly double _pricePerSeat = pricePerSeat;
        private readonly List<MovieTicket> _movieTicketList = [];
        private readonly Movie _movie = movie;

        public double getPricePerSeat()
        {
            return _pricePerSeat;
        }

        public DateTime GetDateAndTime() => _dateAndTime;
    }
}
