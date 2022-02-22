using SparesShop2.Models;
using System.ComponentModel;

namespace SparesShop2.ViewModels
{
    public class SpareCreateViewModel
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
        public IFormFile Image { get; set; }
    }
}
