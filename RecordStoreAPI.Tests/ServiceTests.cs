using Moq;
using RecordStoreAPI.Classes;
using RecordStoreAPI.Repositories;
using RecordStoreAPI.Services;

namespace RecordStoreAPI.Tests;

public class ServiceTests
{
    Mock<IAlbumsRepository> _mockRepository;
    AlbumsService albumsService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IAlbumsRepository>();
        albumsService = new AlbumsService(_mockRepository.Object);
    }

    #region GetAllAlbums method tests
    [Test]
    public void GetAllAlbums_ReturnsListOfAlbumsType()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expected);

        // Act
        var result = albumsService.GetAllAlbums();

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void GetAllAlbums_CallsRepositoryMethodOnce()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expected);

        // Act
        albumsService.GetAllAlbums();

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.GetAllAlbums(), Times.Once());
    }

    [Test]
    public void GetAllAlbums_ReturnsRetrievedAlbums()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expected);

        // Act
        var result = albumsService.GetAllAlbums();

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expected);

        // Act
        var result = albumsService.AddNewAlbum(inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void AddNewAlbum_CallsRespositoryMethodOnce()
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expected);

        // Act
        albumsService.AddNewAlbum(inputAlbum);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.AddNewAlbum(inputAlbum), Times.Once());
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expected);

        // Act
        var result = albumsService.AddNewAlbum(inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion
}
