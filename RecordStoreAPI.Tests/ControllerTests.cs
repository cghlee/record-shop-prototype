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
}
