using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EfProductRepository : IProductRepository
    {
        //Fields & Properties

        private AppDbContext _context;

        //Constructors
        public EfProductRepository(AppDbContext context)
        {
            _context = context;
        }

        //Methods
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public IQueryable<string> GetAllCategories()
        {
            IQueryable<string> categories = _context.Products.Select(p => p.Category).Distinct().OrderBy(c => c);

            return categories;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products
               .Where(p => p.ProductId == productId)
               .FirstOrDefault();
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            return _context.Products
               .Where(p => p.Name.Contains(keyword));
        }

        //Create

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }


        //Upate

        public Product UpdateProduct(Product product)
        {
            Product productToUpdate =
               _context.Products
               .SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Category = product.Category;
                productToUpdate.Description = product.Description;
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                _context.SaveChanges();
            }
            return productToUpdate;
        }

        //Delete

        public bool DeleteProduct(int id)
        {
            Product productToDelete = _context.Products.Find(id);
            if (productToDelete == null)
            {
                return false;
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return true;
        }


    }
}
