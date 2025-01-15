using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordStoreAPI.Classes;
using RecordStoreAPI.Controllers;
using RecordStoreAPI.Services;

namespace RecordStoreAPI.Tests;

public class ControllerTests
{
    Mock<IAlbumsService> _mockService;
    AlbumsController albumsController;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IAlbumsService>();
        albumsController = new AlbumsController(_mockService.Object);
    }

    #region GetAllAlbums method tests
    [Test]
    public void GetAllAlbums_ReturnsOkObjectResult()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expected);

        // Act
        var objectResult = albumsController.GetAllAlbums();

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetAllAlbums_ReturnsListOfAlbumsType()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expected);

        // Act
        var objectResult = albumsController.GetAllAlbums() as OkObjectResult;
        var result = objectResult!.Value as List<Album>;

        // Assert
        Assert.That(result, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void GetAllAlbums_CallsServiceMethodOnce()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expected);

        // Act
        albumsController.GetAllAlbums();

        // Assert
        _mockService.Verify(mockService => mockService.GetAllAlbums(), Times.Once());
    }

    [Test]
    public void GetAllAlbums_ReturnsRetrievedAlbums()
    {
        // Arrange
        var expected = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expected);

        // Act
        var objectResult = albumsController.GetAllAlbums() as OkObjectResult;
        var result = objectResult!.Value as List<Album>;

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
    #endregion

    #region GetAlbumById method tests
    [Test]
    public void GetAlbumById_OnValidId_ReturnsOkObjectResult()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        _mockService.Setup(mockService => mockService.FindAlbumById(2)).Returns(expected);

        // Act
        var objectResult = albumsController.GetAlbumById(2);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        _mockService.Setup(mockService => mockService.FindAlbumById(2)).Returns(expected);

        // Act
        var objectResult = albumsController.GetAlbumById(2) as OkObjectResult;
        var result = objectResult!.Value as Album;

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void GetAlbumById_CallsServiceMethodOnce()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        _mockService.Setup(mockService => mockService.FindAlbumById(2)).Returns(expected);

        // Act
        albumsController.GetAlbumById(2);

        // Assert
        _mockService.Verify(mockService => mockService.FindAlbumById(2), Times.Once());
    }

    [Test]
    public void GetAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        var expected = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        _mockService.Setup(mockService => mockService.FindAlbumById(2)).Returns(expected);

        // Act
        var objectResult = albumsController.GetAlbumById(2) as OkObjectResult;
        var result = objectResult!.Value as Album;

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetAlbumById_OnInvalidId_ReturnsBadRequestObjectResult()
    {
        // Arrange
        Album? expected = null;

        _mockService.Setup(mockService => mockService.FindAlbumById(int.MaxValue)).Returns(expected);

        // Act
        var objectResult = albumsController.GetAlbumById(int.MaxValue);

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region PostNewAlbum method tests
    [Test]
    public void PostNewAlbum_OnValidInput_ReturnsOkObjectResult()
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

        _mockService.Setup(mockService => mockService.AddNewAlbum(inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PostNewAlbum(inputAlbum);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void PostNewAlbum_OnValidInput_ReturnsAlbumWithId()
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

        _mockService.Setup(mockService => mockService.AddNewAlbum(inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PostNewAlbum(inputAlbum) as OkObjectResult;
        var result = objectResult!.Value as Album;

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void PostNewAlbum_OnInvalidInput_ReturnsBadRequestObjectResult()
    {
        // Arrange
        var input = new Album { Name = "Album1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        albumsController.ModelState.AddModelError("Artist", "The Artist field is required.");

        // Act
        var objectResult = albumsController.PostNewAlbum(input) as BadRequestObjectResult;

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region PutAlbumById method tests
    [Test]
    public void PutAlbumById_OnValidInputs_ReturnsOkObjectResult()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void PutAlbumById_OnValidInputs_ReturnsAlbumType()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as OkObjectResult;
        var result = objectResult!.Value as Album;

        // Assert
        Assert.That(result, Is.TypeOf<Album>());
    }

    [Test]
    public void PutAlbumById_CallsServiceMethodOnce()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        albumsController.PutAlbumById(inputId, inputAlbum);

        // Assert
        _mockService.Verify(mockService => mockService.UpdateAlbumById(inputId, inputAlbum), Times.Once());
    }

    [Test]
    public void PutAlbumById_OnValidInputs_ReturnsRetrievedAlbum()
    {
        // Arrange
        var inputId = 2;
        var inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        var expected = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = "Genre2", Year = 2002 };

        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as OkObjectResult;
        var result = objectResult!.Value as Album;

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void PutAlbumById_OnInvalidAlbum_ReturnsBadRequestObjectResult()
    {
        // Arrange
        var inputId = 1;
        var inputAlbum = new Album { Name = "Album1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        albumsController.ModelState.AddModelError("Artist", "The Artist field is required.");

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as BadRequestObjectResult;

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void PutAlbumById_OnInvalidId_ReturnsBadRequestObjectResult()
    {
        // Arrange
        var inputId = int.MaxValue;
        var inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        Album? expected = null;

        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expected);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as BadRequestObjectResult;

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion
}
