namespace StarwarsApi.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGood { get; set; }
        public string? Species { get; set; }
        public string? Gender { get; set; }
        public double Height { get; set; }
        public string? Role { get; set; }
        public string? Image { get; set; }
    }


}
