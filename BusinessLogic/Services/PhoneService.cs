using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Phone>> GetAll(string search)
        {
            var phones = await _context.Phones.ToListAsync();
            await _context.Categories.ToListAsync();
            await _context.Manufacturer.ToListAsync();

            //await Task.Run(() =>
            //{
                if (!string.IsNullOrEmpty(search))
                {
                    phones = phones.Where(p => p.Series.Contains(search)).ToList();
                }
            //}

            return phones;
        }

        //R
        public async Task<Phone> GetPhone(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            return phone;
        }

        //C
        public async Task Create(Phone phone)
        {
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
        }

        //U
        public async Task Update(Phone phone)
        {
            _context.Phones.Update(phone);
            await _context.SaveChangesAsync();
        }

        //D
        public async Task Delete(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
        }
    }
}
