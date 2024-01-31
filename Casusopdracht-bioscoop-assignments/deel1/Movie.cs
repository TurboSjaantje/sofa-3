namespace deel1
{
    public class Movie(string title)
    {

        private readonly string _title = title;
        private readonly List<MovieScreening> _movieScreenings = [];

        public void AddScreening(MovieScreening movieScreening)
        {
            _movieScreenings.Add(movieScreening);
        }

        public string ToString()
        {
            StringBuilder sb = new(_title);
            _movieScreenings.ForEach(m => sb.Append(m.ToString()));
            return sb.ToString();
        }
    }
}
