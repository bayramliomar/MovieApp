namespace MovieApp_.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public Person Person { get; set; }
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Biography { get; set; }
        public string Imdb { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }

    public class Crew
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Job { get; set; }
    }

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
