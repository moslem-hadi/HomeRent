using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
        private const string _adminNameAndPass = "administrator";
        public async Task TrySeedDataAsync()
        {
            var adminRole = new IdentityRole(RoleNames.Administrator);
            if (_roleManager.Roles.All(a => a.Name != adminRole.Name))
                await _roleManager.CreateAsync(adminRole);

            var adminUser = new ApplicationUser { UserName = _adminNameAndPass, Email = _adminNameAndPass };

            if(_userManager.Users.All(a=> a.UserName != adminUser.UserName))
            {
                await _userManager.CreateAsync(adminUser, _adminNameAndPass);
                await _userManager.AddToRoleAsync(adminUser, adminRole.Name!);
            }

            if (!_context.Products.Any())
            {
                var property = new Property
                {
                    Title = "Sea view",
                    Icon = "sea-icon"
                };
                _context.Properties.Add(property);


                _context.Products.Add(new Product
                {
                    Title = "That house by the sea",
                    Description = "It's a house by the sea. And it is BEAUTIFUL.",
                    Price = 140,
                    Pictures = new string[] { "https://a0.muscache.com/im/pictures/29d1ea3a-d557-4852-bdce-123edc3aaace.jpg?im_w=1200" },
                    Properties = new List<Property> { property },
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}