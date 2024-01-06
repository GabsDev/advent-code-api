using Advent_of_code;
using Microsoft.EntityFrameworkCore;

namespace Advent_of_code
{
    class AdventKeyDb : DbContext
    {
        public AdventKeyDb(DbContextOptions<AdventKeyDb> options)
            : base(options) { }

        public DbSet<AdventKey> AdventKeys => Set<AdventKey>();
    }
}


