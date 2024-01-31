namespace deel1
{
    public class MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
    {
        private int RowNr = rowNr;
        private readonly int SeatNr = seatNr;
        private readonly bool IsPremium = isPremium;
        private readonly MovieScreening MovieScreening = movieScreening; 

        public bool IsPremiumticket()
        {
            return IsPremium;
        }

        public double GetPrice() => MovieScreening.PricePerSeat;

        public MovieScreening GetMovieScreening() => MovieScreening;

        public bool IsNonStudentDiscountDay()
        {
            var dayOfWeek = MovieScreening.DateAndTime.DayOfWeek;

            if (dayOfWeek >= DayOfWeek.Friday && dayOfWeek <= DayOfWeek.Sunday) return false;
            return true;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
