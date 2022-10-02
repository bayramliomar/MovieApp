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
}
