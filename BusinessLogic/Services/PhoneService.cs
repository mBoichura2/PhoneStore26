using DataAccess;
using DataAccess.Entities;
using System.Numerics;

//CRUD
namespace BusinessLogic.Services
{
    public class PhoneService
    {
        private PhoneStoreDbContext _context;

        public PhoneService(PhoneStoreDbContext context)
        {
            _context = context;
        }

        //R
        public List<Phone> GetAll(string search)
        {
            var phones = _context.Phones.ToList();
            _context.Categories.ToList();
            _context.Manufacturer.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                phones = phones.Where(p => p.Series.Contains(search)).ToList();
            }

            return phones;
        }

        //R
        public Phone GetPhone(int id)
        {
            var phone = _context.Phones.Find(id);
            return phone;
        }

        //C
        public void Create(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
        }

        //U
        public void Update(Phone phone)
        {
            _context.Phones.Update(phone);
            _context.SaveChanges();
        }

        //D
        public void Delete(int id)
        {
            var phone = _context.Phones.Find(id);
            _context.Phones.Remove(phone);
            _context.SaveChanges();
        }
    }
}
