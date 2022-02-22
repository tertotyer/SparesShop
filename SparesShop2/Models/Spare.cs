using System.ComponentModel;

namespace SparesShop2.Models
{
    public class Spare
    {
        public int Id { get; set; }
        [DisplayName("Модель")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public string Cost { get; set; }
        public Character Character { get; set; }
        [DisplayName("Категория")]
        public int CharacterId { get; set; }
        [DisplayName("Картинка")]
        public string ImagePath { get; set; }
    }
}
