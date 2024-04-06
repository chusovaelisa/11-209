namespace PockemonAPI.Models
{
    public class Pockemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public Breeding Breeding { get; set; }
    }
}
