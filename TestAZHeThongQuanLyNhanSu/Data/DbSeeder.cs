using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Models;

namespace TestAZHeThongQuanLyNhanSu.Data
{
    public class DbSeeder
    {

        public static async Task SeedAsync(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            // Tạo các Role nếu chưa tồn tại
            string[] roles = { "Admin", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Kiểm tra nếu bảng Positions chưa có dữ liệu
            if (!context.Positions.Any())
            {
                context.Positions.AddRange(
                    new Position { Name = "Manager" },
                    new Position { Name = "Staff" }
                );
                await context.SaveChangesAsync();
            }

            // Kiểm tra xem tài khoản Admin đã tồn tại chưa
            if (await userManager.FindByNameAsync("admin") == null)
            {
                // Lấy PositionId cho Admin (ở đây tôi giả sử bạn muốn dùng Position "Manager")
                var position = context.Positions.FirstOrDefault(p => p.Name == "Manager");

                if (position == null)
                {
                    // Nếu không có Position "Manager" (có thể không có dữ liệu trong bảng Positions)
                    position = new Position { Name = "Manager" };
                    context.Positions.Add(position);
                    await context.SaveChangesAsync();
                }

                // Tạo tài khoản Admin
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
                    PositionId = position.Id, // Gán PositionId đã lấy
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
                    // Nếu không có Position "Staff", tạo mới
                    position = new Position { Name = "Staff" };
                    context.Positions.Add(position);
                    await context.SaveChangesAsync();
                }

                // Tạo tài khoản nhân viên
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
                    PositionId = position.Id, // Gán PositionId đã lấy
                    IsActive = true,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(employee, "Employee@123");
                await userManager.AddToRoleAsync(employee, "Employee");
            }
        }
    }
}
