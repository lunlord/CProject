using System.Collections.Generic;

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