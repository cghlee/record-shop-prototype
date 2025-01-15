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

    #region FindAlbumById method tests
    [Test]
    public void FindAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(2)).Returns(expected);

        // Act
        var result = albumsService.FindAlbumById(2);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void FindAlbumById_CallsRepositoryMethodOnce()
    {
        // Arrange
        var expected = new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(2)).Returns(expected);

        // Act
        albumsService.FindAlbumById(2);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.FindAlbumById(2), Times.Once());
    }

    [Test]
    public void FindAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(2)).Returns(expected);

        // Act
        var result = albumsService.FindAlbumById(2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FindAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        Album? expected = null;

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(int.MaxValue)).Returns(expected);

        // Act
        var result = albumsService.FindAlbumById(int.MaxValue);

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

    #region UpdateAlbumById method tests
    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsAlbumType()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void UpdateAlbumById_CallsRepositoryMethodOnce()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        // Act
        albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum), Times.Once());
    }

    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsRetrievedAlbum()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        var inputId = int.MaxValue;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        Album? expected = null;

        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region DeleteAlbumById method tests
    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        var inputId = 2;
        var expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.DeleteAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void DeleteAlbumById_CallsRepositoryMethodOnce()
    {
        // Arrange
        var inputId = 2;
        var expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.DeleteAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.DeleteAlbumById(inputId);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.DeleteAlbumById(inputId), Times.Once());
    }

    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        var inputId = 2;
        var expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockRepository.Setup(mockRepository => mockRepository.DeleteAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }

    [Test]
    public void DeleteAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        var inputId = int.MaxValue;
        Album? expectedRepositoryReturn = null;

        _mockRepository.Setup(mockRepository => mockRepository.DeleteAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion
}
