using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Birdie.Core.Data
{
    public class BirdieContextFactory : IDesignTimeDbContextFactory<BirdieContext>
    {
        public BirdieContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<BirdieContext>()
                .UseNpgsql("Host=localhost;Username={user};Password={pass};Database={database};")
                .Options;

            return new BirdieContext(options);
        }
    }
}