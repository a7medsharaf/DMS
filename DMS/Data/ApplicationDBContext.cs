using DMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DMS.Data
{
    public class ApplicationDBContext:DbContext
    {
        private IConfiguration _configuration { get; set; }
        public ApplicationDBContext(IConfiguration config)
        {
            _configuration = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection_string = _configuration.GetConnectionString("dbconnection");
            optionsBuilder.UseOracle(connection_string);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<KnowledgePool> KnowledgePools { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}
