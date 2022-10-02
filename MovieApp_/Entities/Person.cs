namespace MovieApp_.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Biography { get; set; }
        public string Imdb { get; set; }
        public User User { get; set; }
        public int UserId { get; set; } //foreign key, unique key
    }
}
