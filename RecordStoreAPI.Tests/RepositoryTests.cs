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
        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
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
        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
        _testDbContext.SaveChanges();

        var expectedList = new List<Album>
        {
            expectedAlbum,
        };

        // Act
        var result = albumsRepository.GetAllAlbums();

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedList));
    }
    #endregion

    #region FindAlbumById method tests
    [Test]
    public void FindAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumById(1);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void FindAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.FindAlbumById(1);

        // Assert
        Assert.That(result, Is.EqualTo(expectedAlbum));
    }

    [Test]
    public void FindAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        Album? expected = null;

        // Act
        var result = albumsRepository.FindAlbumById(int.MaxValue);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region AddNewAlbum method tests
    [Test]
    public void AddNewAlbum_ReturnsAlbumType()
    {
        // Arrange
        var inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        var expected = new Album
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
        var inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        var expected = new Album
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
        var originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void UpdateAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        var originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        var inputId = int.MaxValue;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        Album? expected = null;

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsUpdatedAlbum()
    {
        // Arrange
        var originalAlbum = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(originalAlbum);
        _testDbContext.SaveChanges();

        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        // Act
        var result = albumsRepository.UpdateAlbumById(inputId, inputAlbum)!;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id == expected.Id);
            Assert.That(result.Name == expected.Name);
            Assert.That(result.Artist == expected.Artist);
            Assert.That(result.Composer == expected.Composer);
            Assert.That(result.Genre == expected.Genre);
            Assert.That(result.Year == expected.Year);
        });
    }
    #endregion

    #region DeleteAlbumById method tests
    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 1;

        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
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

        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
        _testDbContext.SaveChanges();

        // Act
        var result = albumsRepository.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedAlbum));
    }

    [Test]
    public void DeleteAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;
        Album? expected = null;

        var seedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
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

        var expectedAlbum = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Albums.Add(expectedAlbum);
        _testDbContext.SaveChanges();

        // Act
        albumsRepository.DeleteAlbumById(inputId);

        // Assert
        var result = _testDbContext.Albums.Find(inputId);
        Assert.That(result, Is.Null);
    }
    #endregion
}
