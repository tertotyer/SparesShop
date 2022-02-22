namespace SparesShop2.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Spare> Spares { get; set; }
    }
}
