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
        public int SectionNumber { get; set; }
        public int CellNumber { get; set; }
        public int ManufacturerId { get; set; }
        public int StatusId { get; set; }
        public DateTime StatusDate { get; set; }


        public Company Manufacturer { get; set; }
        public Status Status { get; set; }
    }
}
