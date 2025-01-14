using RecordStoreAPI.Classes;
using RecordStoreAPI.Repositories;

namespace RecordStoreAPI.Services;

public interface IAlbumsService
{
    Album AddNewAlbum(Album newAlbum);
    List<Album> GetAllAlbums();
}

public class AlbumsService : IAlbumsService
{
    private readonly IAlbumsRepository _albumsRepository;
    public AlbumsService(IAlbumsRepository albumsRepository)
    {
        _albumsRepository = albumsRepository;
    }

    public List<Album> GetAllAlbums()
    {
        List<Album> allAlbums = _albumsRepository.GetAllAlbums();
        return allAlbums;
    }

    public Album AddNewAlbum(Album newAlbum)
    {
        Album albumWithIdAdded = _albumsRepository.AddNewAlbum(newAlbum);
        return albumWithIdAdded;
    }
}
