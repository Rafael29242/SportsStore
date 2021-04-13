using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Linq;

namespace SportsStore.Properties.Controllers
{
    public class HomeController : Controller
    {
        //Fields & Properties

        private IProductRepository _repository;  //Private Field

        //Constructors
        public HomeController(IProductRepository repository) //Dependency Injection
                                                             //Inversion of Control
        {
            _repository = repository;

        }


        //Methods

        
        //public IActionResult Index()
        //{

        //    //1. Go to database and get data out.
        //    IQueryable<Product> allProducts;
        //    allProducts = _repository.GetAllProducts();


        //    //2. Send that data into the View
        //    return View(allProducts);
        //}

        public int pageSize = 4;

        // . . .



        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> allProducts = _repository.GetAllProducts();
            IQueryable<Product> someProducts =
               _repository.GetAllProducts()
                         .OrderBy(p => p.ProductId)
                         .Skip((productPage - 1) * pageSize)
                         .Take(pageSize);

            ProductListViewModel plvm = new ProductListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.CurrentPage = productPage;
            pi.ItemsPerPage = pageSize;
            pi.TotalItems = allProducts.Count();

            plvm.PagingInformation = pi;
            plvm.Products = someProducts;


            //ViewBag.ProductCount = allProducts.Count();
            //ViewBag.Paging = pi;

            return View(plvm);

        }

        public IActionResult Categories()
        {
            IQueryable<string> categories = _repository.GetAllCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string id)
        {
            IQueryable<Product> productsWithKeyword =
               _repository.GetProductsByKeyword(id);
            return View(productsWithKeyword);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Product product, int id)
        {
            product.ProductId = id;
            _repository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.Create(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Product product, int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }




    }
}
