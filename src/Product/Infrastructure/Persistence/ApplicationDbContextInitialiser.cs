using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                    await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            if (!_context.Products.Any())
            {
                var property = new Property
                {
                    Title = "Sea view",
                    Icon = "sea-icon"
                };
                _context.Properties.Add(property);

                var product = new Product
                {
                    Title = "That house by the sea",
                    Description = "It's a house by the sea. And it is BEAUTIFUL.",
                    Price = 140,
                    Pictures = new List<string> { "https://a0.muscache.com/im/pictures/29d1ea3a-d557-4852-bdce-123edc3aaace.jpg?im_w=1200" },
                };
                var productProperty = new ProductProperty
                {
                    Product = product,
                    Property = property
                };
                product.Properties = new List<ProductProperty> { productProperty };

                _context.Products.Add(product);

                await _context.SaveChangesAsync();

            }
        }
    }
}