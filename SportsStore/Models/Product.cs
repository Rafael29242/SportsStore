using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//Entity Framework - Code First
namespace SportsStore.Models
{
    [Table("Product")]
    public class Product
    {
        //Fields & Properties

        public int ProductId { get; set;}

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")] //8 total digits, 2 digits are the fraction/ change(cents).
        public decimal Price { get; set; }

        public string Category { get; set; }

        //Constructors

        //Methods
    }
}
