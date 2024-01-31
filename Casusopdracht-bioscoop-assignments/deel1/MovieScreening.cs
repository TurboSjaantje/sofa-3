namespace deel1
{
    public class MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
    {
        public DateTime DateAndTime { get; private set; } = dateAndTime;
        public double PricePerSeat { get; private set; } = pricePerSeat;
        public Movie Movie { get; private set; } = movie;
    }
}
