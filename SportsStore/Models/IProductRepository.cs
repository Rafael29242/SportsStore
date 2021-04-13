using System.Linq;

namespace SportsStore.Models
{
    public interface IProductRepository
    {

        //Create

        public Product Create(Product product);

        //Read
        public IQueryable<Product> GetAllProducts();

        public IQueryable<string> GetAllCategories();

        public Product GetProductById(int productId);
        public IQueryable<Product> GetProductsByKeyword(string keyword);

        //Update

        public Product UpdateProduct(Product product);


        //Delete
        public bool DeleteProduct(int id);

    }
}
