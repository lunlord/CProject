namespace CProject.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int SectionNumber { get; set; }
        public int CellNumber { get; set; }
        public int ManufacturerId { get; set; }
    }
}