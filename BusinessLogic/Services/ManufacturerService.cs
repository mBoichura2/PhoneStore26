//using PhoneStore26.Data;
//using System.Numerics;

//namespace BusinessLogic.Services
//{
//    public class ManufacturerService
//    {
//        private ApplicationDbContext _context;

//        public ManufacturerService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public List<Phone> GetAll(string search)
//        {
//            var phones = _context.Phones.ToList();
//            _context.Categories.ToList();
//            _context.Manufacturer.ToList();

//            if (!string.IsNullOrEmpty(search))
//            {
//                phones = phones.Where(p => p.Series.Contains(search)).ToList();
//            }

//            return phones;
//        }

//        public Phone GetPhone(int id)
//        {
//            var phone = _context.Phones.Find(id);
//            return phone;
//        }

//        public void Create(Phone phone)
//        {
//            _context.Phones.Add(phone);
//            _context.SaveChanges();
//        }

//        public void Update(Phone phone)
//        {
//            _context.Phones.Update(phone);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            var phone = _context.Phones.Find(id);
//            _context.Phones.Remove(phone);
//            _context.SaveChanges();
//        }
//    }
//}
