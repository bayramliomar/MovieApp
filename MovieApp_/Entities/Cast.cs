namespace MovieApp_.Entities
{
    public class Cast
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string RoleName { get; set; }
        public string Character { get; set; }
    }
}
