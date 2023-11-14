using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_Browser.Models
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ImdbDbContext>
    {
        public ImdbDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImdbDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=DemoDb;Trusted_Connection=True;Integrated Security=true;Encrypt=false;");

            return new ImdbDbContext(optionsBuilder.Options);
        }
    }
}
