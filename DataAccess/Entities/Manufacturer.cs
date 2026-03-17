namespace DataAccess.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //Navigation Properties
        public List<Phone> Phone { get; set; } = new List<Phone>();
    }
}
