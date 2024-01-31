namespace deel1
{
    public class Movie(string title)
    {
        public string Title { get; private set; } = title;
        public List<MovieScreening> MovieScreenings { get; init;  } = [];
        public void AddScreening(MovieScreening movieScreening) => MovieScreenings.Add(movieScreening);

        public override string ToString() => string.Join("\n", MovieScreenings.Select(x => x.ToString()));
    }
}
