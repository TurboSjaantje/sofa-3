namespace deel1
{
    public class MovieTicket(int rowNr, int seatNr, bool isPremiumReservation, MovieScreening movieScreening)
    {
        public int RowNr { get; private set; } = rowNr;
        public int SeatNr { get; private set; } = seatNr;
        public bool IsPremium { get; private set; } = isPremiumReservation;
        public MovieScreening MovieScreening { get; private set; } = movieScreening;

        public double GetPrice() => MovieScreening.PricePerSeat;

        public MovieScreening GetMovieScreening() => MovieScreening;

        public bool IsNonStudentDiscountDay()
        {
            var dayOfWeek = MovieScreening.DateAndTime.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday 
                || dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday)
            {
                return true;
            }

            return true;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
