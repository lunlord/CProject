using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CProject.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Возможно не нужно
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
