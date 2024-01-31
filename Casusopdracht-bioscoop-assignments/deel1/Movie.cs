namespace deel1
{
    public class Movie(string title)
    {

        private readonly string Title = title;
        private readonly List<MovieScreening> MovieScreenings = [];

        public void AddScreening(MovieScreening movieScreening) => MovieScreenings.Add(movieScreening);

        public string ToString()
        {
            StringBuilder sb = new(Title);
            MovieScreenings.ForEach(m => sb.Append(m.ToString()));
            return sb.ToString();
        }
    }
}
