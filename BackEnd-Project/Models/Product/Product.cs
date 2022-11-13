using EmbryoFrontToBack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Project.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public int Count { get; set; }
    }
}
