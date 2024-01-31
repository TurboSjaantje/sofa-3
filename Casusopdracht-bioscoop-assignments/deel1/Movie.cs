namespace deel1
{
    public class Movie(string title)
    {

        public string Title { get; private set; } = title;
        public List<MovieScreening> MovieScreenings { get; private set; } = [];

        public void AddScreening(MovieScreening movieScreening) => MovieScreenings.Add(movieScreening);

        public string ToString()
        {
            StringBuilder sb = new(Title);
            MovieScreenings.ForEach(m => sb.Append(m.ToString()));
            return sb.ToString();
        }
    }
}
