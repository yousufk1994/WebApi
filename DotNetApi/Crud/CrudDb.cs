using DotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Crud
{
    public class CrudDb: DbContext
    {
        public CrudDb(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<DbValues> forModel { get; set; }
    }
}
