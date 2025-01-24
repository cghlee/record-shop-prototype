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
        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.GetAllAlbums();

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void GetAllAlbums_CallsRepositoryMethodOnce()
    {
        // Arrange
        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expectedRepositoryReturn);

        // Act
        albumsService.GetAllAlbums();

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.GetAllAlbums(), Times.Once());
    }

    [Test]
    public void GetAllAlbums_ReturnsRetrievedAlbums()
    {
        // Arrange
        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllAlbums()).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.GetAllAlbums();

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedRepositoryReturn));
    }
    #endregion

    #region FindAlbumById method tests
    [Test]
    public void FindAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void FindAlbumById_CallsRepositoryMethodOnce()
    {
        // Arrange
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.FindAlbumById(inputId);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.FindAlbumById(inputId), Times.Once());
    }

    [Test]
    public void FindAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }

    [Test]
    public void FindAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;

        Album? expectedRepositoryReturn = null;
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region FindAlbumsByYear method tests
    [Test]
    public void FindAlbumsByYear_OnValidYear_ReturnsListOfAlbumsType()
    {
        // Arrange
        int inputYear = 2002;

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByYear(inputYear)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void FindAlbumsByYear_CallsRepositoryMethodOnce()
    {
        // Arrange
        int inputYear = 2002;

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByYear(inputYear)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.FindAlbumsByYear(inputYear);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.FindAlbumsByYear(inputYear), Times.Once());
    }

    [Test]
    public void FindAlbumsByYear_OnValidYear_ReturnsRetrievedAlbums()
    {
        // Arrange
        int inputYear = 2002;

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByYear(inputYear)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedRepositoryReturn));
    }

    [Test]
    public void FindAlbumsByYear_OnInvalidYear_ReturnsNull()
    {
        // Arrange
        int inputYear = int.MaxValue;

        List<Album>? expectedRepositoryReturn = null;
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByYear(inputYear)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByYear(inputYear);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region FindAlbumsByArtist method tests
    [Test]
    public void FindAlbumsByArtist_OnValidArtist_ReturnsListOfAlbumsType()
    {
        // Arrange
        string inputArtist = "Artist2";

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByArtist(inputArtist)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void FindAlbumsByArtist_CallsRepositoryMethodOnce()
    {
        // Arrange
        string inputArtist = "Artist2";

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByArtist(inputArtist)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.FindAlbumsByArtist(inputArtist);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.FindAlbumsByArtist(inputArtist), Times.Once());
    }

    [Test]
    public void FindAlbumsByArtist_OnValidArtist_ReturnsRetrievedAlbums()
    {
        // Arrange
        string inputArtist = "Artist2";

        List<Album> expectedRepositoryReturn = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist2", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" },
            new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" },
        };

        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByArtist(inputArtist)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedRepositoryReturn));
    }

    [Test]
    public void FindAlbumsByArtist_OnInvalidArtist_ReturnsNull()
    {
        // Arrange
        string inputArtist = "Artisttt";

        List<Album>? expectedRepositoryReturn = null;
        _mockRepository.Setup(mockRepository => mockRepository.FindAlbumsByArtist(inputArtist)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.FindAlbumsByArtist(inputArtist);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region AddNewAlbum method tests
    [Test]
    public void AddNewAlbum_ReturnsAlbumType()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };

        Album expectedRepositoryReturn = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.AddNewAlbum(inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void AddNewAlbum_CallsRespositoryMethodOnce()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };

        Album expectedRepositoryReturn = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.AddNewAlbum(inputAlbum);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.AddNewAlbum(inputAlbum), Times.Once());
    }

    [Test]
    public void AddNewAlbum_ReturnsAlbumWithId()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001, AlbumArtUrl = "Url1" };

        Album expectedRepositoryReturn = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        _mockRepository.Setup(mockRepository => mockRepository.AddNewAlbum(inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.AddNewAlbum(inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region UpdateAlbumById method tests
    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void UpdateAlbumById_CallsRepositoryMethodOnce()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum), Times.Once());
    }

    [Test]
    public void UpdateAlbumById_OnValidInputs_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }

    [Test]
    public void UpdateAlbumById_OnInvalidId_ReturnsNull()
    {
        // Arrange
        int inputId = int.MaxValue;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };

        Album? expectedRepositoryReturn = null;
        _mockRepository.Setup(mockRepository => mockRepository.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.UpdateAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region DeleteAlbumById method tests
    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
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
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
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
        int inputId = 2;

        Album expectedRepositoryReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002, AlbumArtUrl = "Url2" };
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
        int inputId = int.MaxValue;

        Album? expectedRepositoryReturn = null;
        _mockRepository.Setup(mockRepository => mockRepository.DeleteAlbumById(inputId)).Returns(expectedRepositoryReturn);

        // Act
        var result = albumsService.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion
}
