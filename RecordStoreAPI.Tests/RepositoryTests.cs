using Microsoft.EntityFrameworkCore;
using RecordStoreAPI.Classes;
using RecordStoreAPI.DbContexts;
using RecordStoreAPI.Repositories;

namespace RecordStoreAPI.Tests;

public class RepositoryTests
{
    AlbumsDbContext _testDbContext;
    AlbumsRepository albumsRepository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AlbumsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _testDbContext = new AlbumsDbContext(options);
        albumsRepository = new AlbumsRepository(_testDbContext);
    }

    [TearDown]
    public void Teardown()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }

    #region GetAllAlbums method tests
    [Test]
    public void GetAllAlbums_ReturnsListOfAlbumsType()
    {
        // Arrange
        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.GetAllAlbums();

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void GetAllAlbums_ReturnsRetrievedAlbums()
    {
        // Arrange
        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        List<Album> expected = new List<Album>
        {
            seedAlbum,
        };

        // Act
        var result = albumsRepository.GetAllAlbums();

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
    #endregion

    #region FindAlbumById method tests
    [Test]
    public void FindAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 1;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void FindAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 1;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(seedAlbum));
    }

    [Test]
    public void FindAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;
        Album? expected = null;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region FindAlbumsByYear method tests
    [Test]
    public void FindAlbumsByYear_OnValidYear_ReturnsListOfAlbumsType()
    {
        // Arrange
        int inputYear = 2001;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void FindAlbumsByYear_OnValidYear_ReturnsRetrievedAlbums()
    {
        // Arrange
        int inputYear = 2001;

        Album seedAlbum1 = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        Album seedAlbum2 = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url2" };
        Album seedAlbum3 = new Album { Id = 3, Name = "Album3", Artist = "Artist3", Composer = "Composer3", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url3" };

        List<Album> seedAlbums = new List<Album>
        { 
            seedAlbum1,
            seedAlbum2,
            seedAlbum3
        };

        _testDbContext.Albums.AddRange(seedAlbums);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.EquivalentTo(seedAlbums));
    }

    [Test]
    public void FindAlbumsByYear_OnInvalidYear_ReturnsNull()
    {
        // Arrange
        int inputYear = int.MaxValue;
        List<Album>? expected = null;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.AddRange(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region FindAlbumsByArtist method tests
    [Test]
    public void FindAlbumsByArtist_OnValidArtist_ReturnsListOfAlbumsType()
    {
        // Arrange
        string inputArtist = "Artist1";

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void FindAlbumsByArtist_OnValidArtist_ReturnsRetrievedAlbums()
    {
        // Arrange
        string inputArtist = "Artist2";

        Album seedAlbum1 = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        Album seedAlbum2 = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        Album seedAlbum3 = new Album { Id = 3, Name = "Album3", Artist = "Artist2", Composer = "Composer3", Genre = Genre.Classical, Year = 2003, AlbumArtUrl = "Url3" };
        Album seedAlbum4 = new Album { Id = 4, Name = "Album4", Artist = "Artist3", Composer = "Composer4", Genre = Genre.Opera, Year = 2004, AlbumArtUrl = "Url4" };

        List<Album> seedAlbums = new List<Album>
        {
            seedAlbum1,
            seedAlbum2,
            seedAlbum3,
            seedAlbum4,
        };

        List<Album> expected = new List<Album>
        {
            seedAlbum2,
            seedAlbum3,
        };

        _testDbContext.Albums.AddRange(seedAlbums);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void FindAlbumsByArtist_OnInvalidArtist_ReturnsNull()
    {
        // Arrange
        string inputArtist = "Artist4";

        Album seedAlbum1 = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        Album seedAlbum2 = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        Album seedAlbum3 = new Album { Id = 3, Name = "Album3", Artist = "Artist2", Composer = "Composer3", Genre = Genre.Classical, Year = 2003, AlbumArtUrl = "Url3" };
        Album seedAlbum4 = new Album { Id = 4, Name = "Album4", Artist = "Artist3", Composer = "Composer4", Genre = Genre.Opera, Year = 2004, AlbumArtUrl = "Url4" };

        List<Album> seedAlbums = new List<Album>
        {
            seedAlbum1,
            seedAlbum2,
            seedAlbum3,
            seedAlbum4,
        };

        List<Album>? expected = null;

        // Act
        var result = albumsRepository.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region AddNewAlbum method tests
    [Test]
    public void AddNewAlbum_ReturnsAlbumType()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };

        Album expected = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        // Act
        var result = albumsRepository.AddNewAlbum(inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void AddNewAlbum_ReturnsAlbumWithId()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };

        Album expected = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        // Act
        var result = albumsRepository.AddNewAlbum(inputAlbum);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expected.Id));
            Assert.That(result.Name, Is.EqualTo(expected.Name));
            Assert.That(result.Artist, Is.EqualTo(expected.Artist));
            Assert.That(result.Composer, Is.EqualTo(expected.Composer));
            Assert.That(result.Genre, Is.EqualTo(expected.Genre));
            Assert.That(result.Year, Is.EqualTo(expected.Year));
        });
    }
    #endregion

    #region UpdateAlbumById method tests
    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void UpdateAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album? expected = null;

        Album originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsUpdatedAlbum()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum)!;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expected.Id));
            Assert.That(result.Name, Is.EqualTo(expected.Name));
            Assert.That(result.Artist, Is.EqualTo(expected.Artist));
            Assert.That(result.Composer, Is.EqualTo(expected.Composer));
            Assert.That(result.Genre, Is.EqualTo(expected.Genre));
            Assert.That(result.Year, Is.EqualTo(expected.Year));
        });
    }
    #endregion

    #region DeleteAlbumById method tests
    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 1;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 1;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(seedAlbum));
    }

    [Test]
    public void DeleteAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;

        Album? expected = null;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DeleteAlbumById_OnValidId_DeletesAlbumFromDatabase()
    {
        // Arrange
        int inputId = 1;

        Album seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };
        _testDbContext.Albums.Add(seedAlbum);
        _testDbContext.SaveChanges();

        // Act
        albumsRepository.DeleteAlbumById(inputId);

        // Assert
        var result = _testDbContext.Albums.Find(inputId);
        Assert.That(result, Is.Null);
    }
    #endregion
}
