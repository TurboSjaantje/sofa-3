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
            throw new NotImplementedException();
        }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "";
        }
    }
}
