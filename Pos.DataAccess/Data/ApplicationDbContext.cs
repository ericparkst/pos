using Pos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Pos.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Tables
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
            .HasOne(i => i.Category)
            .WithMany()
            .HasForeignKey(i => i.CategoryCode)
            .HasPrincipalKey(c => c.CategoryCode);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DeptCode = "1", NameEN = "Produce", NameKO = "청과"},
                new Department { Id = 2, DeptCode = "2", NameEN = "Fish", NameKO = "수산" },
                new Department { Id = 3, DeptCode = "3", NameEN = "Meat", NameKO = "정육" },
                new Department { Id = 4, DeptCode = "4", NameEN = "Deli", NameKO = "델리" },
                new Department { Id = 5, DeptCode = "5", NameEN = "Houseware", NameKO = "하우스웨어" },
                new Department { Id = 6, DeptCode = "6", NameEN = "Grocery", NameKO = "그로서리" }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryCode = "201", NameEN = "Eggplant", NameKO = "가지류", DeptCode = "1" },
                new Category { Id = 2, CategoryCode = "202", NameEN = "Potato", NameKO = "감자류", DeptCode = "1" },
                new Category { Id = 3, CategoryCode = "203", NameEN = "Sweet Potato", NameKO = "고구마류", DeptCode = "1" }
                );
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, ItemCode = "12010001", NameEN = "Korean Eggplant", NameKO = "한국 가지", DeptCode = "1", CategoryCode = "201", ImageUrl="", Description=null},
                new Item { Id = 2, ItemCode = "12010002", NameEN = "American Eggplant", NameKO = "미국 가지", DeptCode = "1", CategoryCode = "201", ImageUrl = "", Description = null },
                new Item { Id = 3, ItemCode = "12020003", NameEN = "Idaho Potato", NameKO = "아이다호 감자", DeptCode = "1", CategoryCode = "202", ImageUrl = "", Description = null },
                new Item { Id = 4, ItemCode = "12020004", NameEN = "Korean Sweet Potato", NameKO = "한국 고구마", DeptCode = "1", CategoryCode = "203", ImageUrl = "", Description = null },
                new Item { Id = 5, ItemCode = "12020005", NameEN = "American Sweet Potato", NameKO = "미국 고구마", DeptCode = "1", CategoryCode = "203", ImageUrl = "", Description = null }
                ); 
        }
    }
}
