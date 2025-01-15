using RecordStoreAPI.Classes;
using RecordStoreAPI.Repositories;

namespace RecordStoreAPI.Services;

public interface IAlbumsService
{
    Album AddNewAlbum(Album newAlbum);
    Album? FindAlbumById(int id);
    List<Album> GetAllAlbums();
    Album? UpdateAlbumById(int id, Album albumToPut);
    Album? DeleteAlbumById(int id);
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

    public Album? FindAlbumById(int id)
    {
        Album? foundAlbum = _albumsRepository.FindAlbumById(id);
        return foundAlbum;
    }

    public Album AddNewAlbum(Album newAlbum)
    {
        Album albumWithIdAdded = _albumsRepository.AddNewAlbum(newAlbum);
        return albumWithIdAdded;
    }

    public Album? UpdateAlbumById(int id, Album albumToPut)
    {
        Album? updatedAlbum = _albumsRepository.UpdateAlbumById(id, albumToPut);
        return updatedAlbum;
    }

    public Album? DeleteAlbumById(int id)
    {
        Album? deletedAlbum = _albumsRepository.DeleteAlbumById(id);
        return deletedAlbum;
    }
}
