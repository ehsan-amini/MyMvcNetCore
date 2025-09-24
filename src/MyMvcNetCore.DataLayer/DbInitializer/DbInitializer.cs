using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.Commen;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.Entities.Identity;

namespace MyMvcNetCore.DataLayer.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MyMvcNetCoreDbContext _dbContext;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MyMvcNetCoreDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Count() > 0)
                    _dbContext.Database.Migrate();
            }
            catch (Exception ex) { }

            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Admin)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "ehsan",
                    Email = "ehsan.mamini@gmail.com",
                    PhoneNumber = "004917632050420",
                    FirstName= "Ehsan",
                    LastName="Mohammadamini",
                    IsActive =true,
                    EmailConfirmed=true 



                }, "123456").GetAwaiter().GetResult();

                ApplicationUser user = _dbContext.Users.FirstOrDefault(u => u.Email == "ehsan.mamini@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
