using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using ContactManagerAPI.Controllers;
using ContactManagerAPI.Data;

namespace ContactManagerAPITests
{
    public class ContactsControllerTests
    {
        private readonly ContactDbContext _context;
        private readonly ContactsController _controller;

        public ContactsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactManagerDB")
                .Options;

            _context = new ContactDbContext(options);
            _controller = new ContactsController(_context);
        }

        [Fact]
        public async Task GetContacts_ReturnsAllContacts()
        {
            // Arrange
            var contact = new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetContacts();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Contact>>>(result);
            var contacts = Assert.IsType<List<Contact>>(actionResult.Value);
            Assert.Single(contacts);
        }

        // Add additional tests for POST, PUT, DELETE
    }
}
