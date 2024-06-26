using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI.Models;

namespace WebAPI
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\MSSQLSERVER2019",
                InitialCatalog = "Blog",
                UserID = "sa",
                Password = "sasa",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
