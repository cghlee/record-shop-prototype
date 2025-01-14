using Microsoft.EntityFrameworkCore;
using RecordShopAPI.Classes;

namespace RecordShopAPI.DbContexts;

public class RecordsDbContext : DbContext
{
    public DbSet<Record> Records { get; set; }

    public RecordsDbContext(DbContextOptions<RecordsDbContext> options)
        : base(options) { }
}
