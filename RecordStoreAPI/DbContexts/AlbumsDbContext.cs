using Microsoft.EntityFrameworkCore;
using RecordStoreAPI.Classes;

namespace RecordStoreAPI.DbContexts;

public class AlbumsDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; }

    public AlbumsDbContext(DbContextOptions<AlbumsDbContext> options)
        : base(options) { }
}
