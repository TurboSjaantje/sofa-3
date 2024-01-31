namespace deel1
{
    public class MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
    {
        public DateTime DateAndTime { get; set; } = dateAndTime;
        public double PricePerSeat { get; } = pricePerSeat;
        public Movie Movie { get; set; } = movie;
    }
}
