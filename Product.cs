using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore
{
    [Table(name: "products")]
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desccribe { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
