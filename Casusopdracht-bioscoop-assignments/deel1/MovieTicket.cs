namespace deel1
{
    public class MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
    {
        private int _rowNr = rowNr;
        private readonly int _seatNr = seatNr;
        private readonly bool _isPremium = isPremium;
        private readonly MovieScreening _movieScreening = movieScreening; 

        public bool IsPremiumticket()
        {
            return _isPremium;
        }

        public double GetPrice() => _movieScreening.getPricePerSeat();

        public MovieScreening GetMovieScreening() => _movieScreening;

        public bool IsNonStudentDiscountDay()
        {
            var dayOfWeek = _movieScreening.GetDateAndTime().DayOfWeek;

            if (dayOfWeek >= DayOfWeek.Friday && dayOfWeek <= DayOfWeek.Sunday) return false;
            return true;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
