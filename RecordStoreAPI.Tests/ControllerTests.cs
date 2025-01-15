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
        List<Album> expectedResultValue = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expectedResultValue);

        // Act
        var objectResult = albumsController.GetAllAlbums();

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetAllAlbums_ReturnsListOfAlbumsType()
    {
        // Arrange
        List<Album> expectedResultValue = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expectedResultValue);

        // Act
        var objectResult = albumsController.GetAllAlbums() as OkObjectResult;
        var resultValue = objectResult!.Value as List<Album>;

        // Assert
        Assert.That(resultValue, Is.TypeOf<List<Album>>());
    }

    [Test]
    public void GetAllAlbums_CallsServiceMethodOnce()
    {
        // Arrange
        List<Album> expectedResultValue = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expectedResultValue);

        // Act
        albumsController.GetAllAlbums();

        // Assert
        _mockService.Verify(mockService => mockService.GetAllAlbums(), Times.Once());
    }

    [Test]
    public void GetAllAlbums_ReturnsRetrievedAlbums()
    {
        // Arrange
        List<Album> expectedResultValue = new List<Album>
        {
            new Album { Id = 1, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllAlbums()).Returns(expectedResultValue);

        // Act
        var objectResult = albumsController.GetAllAlbums() as OkObjectResult;
        var resultValue = objectResult!.Value as List<Album>;

        // Assert
        Assert.That(resultValue, Is.EquivalentTo(expectedResultValue));
    }
    #endregion

    #region GetAlbumById method tests
    [Test]
    public void GetAlbumById_OnValidId_ReturnsOkObjectResult()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
        _mockService.Setup(mockService => mockService.FindAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.GetAlbumById(inputId);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetAlbumById_OnValidId_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
        _mockService.Setup(mockService => mockService.FindAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.GetAlbumById(inputId) as OkObjectResult;
        var resultValue = objectResult!.Value as Album;

        // Assert
        Assert.That(resultValue, Is.TypeOf<Album>());
    }

    [Test]
    public void GetAlbumById_CallsServiceMethodOnce()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
        _mockService.Setup(mockService => mockService.FindAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        albumsController.GetAlbumById(inputId);

        // Assert
        _mockService.Verify(mockService => mockService.FindAlbumById(inputId), Times.Once());
    }

    [Test]
    public void GetAlbumById_OnValidId_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
        _mockService.Setup(mockService => mockService.FindAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.GetAlbumById(inputId) as OkObjectResult;
        var resultValue = objectResult!.Value as Album;

        // Assert
        Assert.That(resultValue, Is.EqualTo(expectedServiceReturn));
    }

    [Test]
    public void GetAlbumById_OnInvalidId_ReturnsBadRequestObjectResult()
    {
        // Arrange
        int inputId = int.MaxValue;

        Album? expectedServiceReturn = null;
        _mockService.Setup(mockService => mockService.FindAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.GetAlbumById(inputId);

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region PostNewAlbum method tests
    [Test]
    public void PostNewAlbum_OnValidInput_ReturnsOkObjectResult()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };

        Album expectedServiceReturn = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        _mockService.Setup(mockService => mockService.AddNewAlbum(inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PostNewAlbum(inputAlbum);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void PostNewAlbum_OnValidInput_ReturnsAlbumWithId()
    {
        // Arrange
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };

        Album expectedServiceReturn = new Album
        {
            Id = 1,
            Name = inputAlbum.Name,
            Artist = inputAlbum.Artist,
            Composer = inputAlbum.Composer,
            Genre = inputAlbum.Genre,
            Year = inputAlbum.Year
        };

        _mockService.Setup(mockService => mockService.AddNewAlbum(inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PostNewAlbum(inputAlbum) as OkObjectResult;
        var resultValue = objectResult!.Value as Album;

        // Assert
        Assert.That(resultValue, Is.EqualTo(expectedServiceReturn));
    }

    [Test]
    public void PostNewAlbum_OnInvalidInput_ReturnsBadRequestObjectResult()
    {
        // Arrange
        Album input = new Album { Name = "Album1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
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
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void PutAlbumById_OnValidInputs_ReturnsAlbumType()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as OkObjectResult;
        var resultValue = objectResult!.Value as Album;

        // Assert
        Assert.That(resultValue, Is.TypeOf<Album>());
    }

    [Test]
    public void PutAlbumById_CallsServiceMethodOnce()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedServiceReturn);

        // Act
        albumsController.PutAlbumById(inputId, inputAlbum);

        // Assert
        _mockService.Verify(mockService => mockService.UpdateAlbumById(inputId, inputAlbum), Times.Once());
    }

    [Test]
    public void PutAlbumById_OnValidInputs_ReturnsRetrievedAlbum()
    {
        // Arrange
        int inputId = 2;
        Album inputAlbum = new Album { Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as OkObjectResult;
        var resultValue = objectResult!.Value as Album;

        // Assert
        Assert.That(resultValue, Is.EqualTo(expectedServiceReturn));
    }

    [Test]
    public void PutAlbumById_OnInvalidAlbum_ReturnsBadRequestObjectResult()
    {
        // Arrange
        int inputId = 1;
        Album inputAlbum = new Album { Name = "Album1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };
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
        int inputId = int.MaxValue;
        Album inputAlbum = new Album { Name = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = Genre.Classical, Year = 2001 };

        Album? expectedServiceReturn = null;
        _mockService.Setup(mockService => mockService.UpdateAlbumById(inputId, inputAlbum)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.PutAlbumById(inputId, inputAlbum) as BadRequestObjectResult;

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region DeleteAlbumById method tests
    [Test]
    public void DeleteAlbumById_OnValidId_ReturnsNoContentResult()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.DeleteAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var objectResult = albumsController.DeleteAlbumById(inputId);

        // Assert
        Assert.That(objectResult, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void DeleteAlbumById_CallsServiceMethodOnce()
    {
        // Arrange
        int inputId = 2;

        Album expectedServiceReturn = new Album { Id = 2, Name = "Album2", Artist = "Artist2", Composer = "Composer2", Genre = Genre.Opera, Year = 2002 };
        _mockService.Setup(mockService => mockService.DeleteAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        albumsController.DeleteAlbumById(inputId);

        // Assert
        _mockService.Verify(mockService => mockService.DeleteAlbumById(inputId), Times.Once());
    }

    [Test]
    public void DeleteAlbumById_OnInvalidId_ReturnsBadRequestObjectResult()
    {
        // Arrange
        int inputId = int.MaxValue;

        Album? expectedServiceReturn = null;
        _mockService.Setup(mockService => mockService.DeleteAlbumById(inputId)).Returns(expectedServiceReturn);

        // Act
        var result = albumsController.DeleteAlbumById(inputId);

        // Assert
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion
}
