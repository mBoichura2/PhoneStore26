namespace DataAccess.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Series { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        //Navigation Properties
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
