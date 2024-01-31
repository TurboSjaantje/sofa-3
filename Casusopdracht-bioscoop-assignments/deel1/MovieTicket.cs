namespace deel1
{
    public class MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
    {
        public int RowNr { get; private set; } = rowNr;
        public int SeatNr { get; private set; } = seatNr;
        public bool IsPremium { get; private set; } = isPremium;
        public MovieScreening MovieScreening { get; private set; } = movieScreening; 

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
