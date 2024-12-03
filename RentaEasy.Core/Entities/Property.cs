namespace RentaEasy.Core.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Location { get; set; }
    }
}
