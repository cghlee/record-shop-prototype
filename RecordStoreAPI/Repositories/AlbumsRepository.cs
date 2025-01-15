using RecordStoreAPI.Classes;
using RecordStoreAPI.DbContexts;

namespace RecordStoreAPI.Repositories;

public interface IAlbumsRepository
{
    List<Album> GetAllAlbums();
    Album AddNewAlbum(Album newAlbum);
    Album? FindAlbumById(int id);
    Album? UpdateAlbumById(int id, Album albumToPut);
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

    public Album? FindAlbumById(int id)
    {
        Album? foundAlbum = _albumsDbContext.Albums.FirstOrDefault(album => album.Id == id);
        return foundAlbum;
    }

    public Album AddNewAlbum(Album newAlbum)
    {
        _albumsDbContext.Albums.Add(newAlbum);
        _albumsDbContext.SaveChanges();
        return newAlbum;
    }

    public Album? UpdateAlbumById(int id, Album albumToPut)
    {
        Album? foundAlbum = FindAlbumById(id);

        if (foundAlbum == null)
            return foundAlbum;

        foundAlbum.Name = albumToPut.Name;
        foundAlbum.Artist = albumToPut.Artist;
        foundAlbum.Composer = albumToPut.Composer;
        foundAlbum.Genre = albumToPut.Genre;
        foundAlbum.Year = albumToPut.Year;
        _albumsDbContext.SaveChanges();

        return foundAlbum;
    }
}
