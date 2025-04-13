using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Models;

namespace TestAZHeThongQuanLyNhanSu.Data
{
    public class DbSeeder
    {

        public static async Task SeedAsync(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            
            string[] roles = { "Admin", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

           
            if (!context.Positions.Any())
            {
                context.Positions.AddRange(
                    new Position { Name = "Manager" },
                    new Position { Name = "Staff" }
                );
                await context.SaveChangesAsync();
            }

          
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var position = context.Positions.FirstOrDefault(p => p.Name == "Manager");

                if (position == null)
                {
                    
                    position = new Position { Name = "Manager" };
                    context.Positions.Add(position);
                    await context.SaveChangesAsync();
                }

                var admin = new Employee
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Gender = "Male",
                    Address = "123 Admin Street",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    StartDate = DateTime.Now,
                    PhoneNumber = "0123456789",
                    PositionId = position.Id, 
                    IsActive = true,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
            if (await userManager.FindByNameAsync("employee1") == null)
            {
                var position = context.Positions.FirstOrDefault(p => p.Name == "Staff");

                if (position == null)
                {
                
                    position = new Position { Name = "Staff" };
                    context.Positions.Add(position);
                    await context.SaveChangesAsync();
                }

                var employee = new Employee
                {
                    UserName = "employee1",
                    FullName = "Employee One",
                    Email = "employee1@gmail.com",
                    Gender = "Female",
                    Address = "456 Employee Street",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    StartDate = DateTime.Now,
                    PhoneNumber = "0123456790",
                    PositionId = position.Id, 
                    IsActive = true,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(employee, "Employee@123");
                await userManager.AddToRoleAsync(employee, "Employee");
            }
        }
    }
}
