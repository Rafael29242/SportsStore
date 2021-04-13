using System.Linq;

namespace SportsStore.Models.ViewModels
{
    public class ProductListViewModel  // Data Transfer Object -DTO
    {
        //   F i e l d s   &   P r o p e r t i e s

        public IQueryable<Product> Products { get; set; }

        public PagingInfo               PagingInformation { get; set; }

        //   C o n s t r u c t o r s

        //   M e t h o d s
    }
}
