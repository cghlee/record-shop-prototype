using RecordStoreAPI.Classes;
using RecordStoreAPI.DbContexts;

namespace RecordStoreAPI.Repositories;

public interface IAlbumsRepository
{
    List<Album> GetAllAlbums();
    Album AddNewAlbum(Album newAlbum);
}

public class AlbumsRepository : IAlbumsRepository
{
    private readonly AlbumsDbContext _albumsDbContext;
    public AlbumsRepository(AlbumsDbContext albumsDbContext)
    {
        _albumsDbContext = albumsDbContext;
    }

    public List<Album> GetAllAlbums()
    {
        List<Album> allAlbums = _albumsDbContext.Albums.ToList();
        return allAlbums;
    }

    public Album AddNewAlbum(Album newAlbum)
    {
        _albumsDbContext.Albums.Add(newAlbum);
        _albumsDbContext.SaveChanges();
        return newAlbum;
    }
}
