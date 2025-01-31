﻿using RecordStoreAPI.Classes;
using RecordStoreAPI.DbContexts;

namespace RecordStoreAPI.Repositories;

public interface IAlbumsRepository
{
    List<Album> GetAllAlbums();
    Album? FindAlbumById(int id);
    List<Album>? FindAlbumsByYear(int inputYear);
    List<Album>? FindAlbumsByArtist(string artist);
    Album AddNewAlbum(Album newAlbum);
    Album? UpdateAlbumById(int id, Album albumToPut);
    Album? DeleteAlbumById(int id);
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

    public List<Album>? FindAlbumsByYear(int inputYear)
    {
        List<Album> albumsFromYear = _albumsDbContext.Albums.Where(album => album.Year == inputYear)
                                                            .ToList();

        if (albumsFromYear.Count == 0)
            return null;

        return albumsFromYear;
    }

    public List<Album>? FindAlbumsByArtist(string artist)
    {
        List<Album> albumsByArtist = _albumsDbContext.Albums.Where(album => album.Artist.ToLower().Contains(artist.ToLower()))
                                                            .ToList();

        if (albumsByArtist.Count == 0)
            return null;

        return albumsByArtist;
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
            return null;

        foundAlbum.Name = albumToPut.Name;
        foundAlbum.Artist = albumToPut.Artist;
        foundAlbum.Composer = albumToPut.Composer;
        foundAlbum.Genre = albumToPut.Genre;
        foundAlbum.Year = albumToPut.Year;
        _albumsDbContext.SaveChanges();

        return foundAlbum;
    }

    public Album? DeleteAlbumById(int id)
    {
        Album? foundAlbum = FindAlbumById(id);

        if (foundAlbum == null)
            return null;

        _albumsDbContext.Remove(foundAlbum);
        _albumsDbContext.SaveChanges();

        return foundAlbum;
    }
}
