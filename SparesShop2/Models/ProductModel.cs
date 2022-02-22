using SparesShop2.Data;

namespace SparesShop2.Models
{
    public class ProductModel
    {
        public ApplicationDbContext _context;

        private List<Spare> products;
        public ProductModel(ApplicationDbContext context)
        {
            _context = context;
            this.products = _context.Spare.ToList();
        }
        public List<Spare> findAll()
        {
            return this.products;
        }
        public Spare find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }
    }
}
