using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ManufacturerId { get; set; }
        public Company Manufacturer { get; set; }
    }
}
