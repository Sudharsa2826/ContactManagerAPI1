using ContactManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactDbContext _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
