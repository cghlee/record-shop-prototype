using RecordStoreAPI.Classes;
using RecordStoreAPI.Repositories;

namespace RecordStoreAPI.Services;

public interface IAlbumsService
{
    List<Album> GetAllAlbums();
    Album? FindAlbumById(int id);
    List<Album>? FindAlbumsByYear(int year);
    Album AddNewAlbum(Album newAlbum);
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

    public List<Album>? FindAlbumsByYear(int year)
    {
        List<Album>? albumsFromYear = _albumsRepository.FindAlbumsByYear(year);
        return albumsFromYear;
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
