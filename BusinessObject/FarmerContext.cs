using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class FarmerContext : DbContext
    {
        public FarmerContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FarmerDB"));
        }
        public virtual DbSet<Farmer> Farmers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Farmer>().HasData(
                new Farmer
                {
                    FarmerId = new Guid("453d9985-5b77-42f7-91c7-c1ab9022cf4b"),
                    FarmerCode = "F001",
                    FarmerName = "Nguyễn Văn A",
                    FarmerNameEN = "Nguyen Van A",
                    Address = "123 Đường ABC, TP.HCM",
                    Phone1 = "0901234567",
                    Phone2 = "0912345678",
                    InsertDate = new DateTime(2025, 8, 16, 14, 0, 0)
                },
                new Farmer
                {
                    FarmerId = new Guid("6fecbe2b-e2b0-4825-9984-2e437bff42d0"),
                    FarmerCode = "F002",
                    FarmerName = "Trần Thị B",
                    FarmerNameEN = "Tran Thi B",
                    Address = "456 Đường XYZ, Hà Nội",
                    Phone1 = "0987654321",
                    Phone2 = "0976543210",
                    InsertDate = new DateTime(2025, 8, 16, 14, 0, 0)
                }
            );
        }
    }
}
