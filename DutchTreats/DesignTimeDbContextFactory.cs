using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DutchTreats.Data;

namespace DutchTreats
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DutchContext>
    {
        public DutchContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DutchContext>();
            var connectionString = configuration.GetConnectionString("DutchConnectionString");
            builder.UseSqlServer(connectionString);
            return new DutchContext(builder.Options);
        }

    }
}
