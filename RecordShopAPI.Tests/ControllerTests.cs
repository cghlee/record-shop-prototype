using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShopAPI.Classes;
using RecordShopAPI.Controllers;
using RecordShopAPI.Services;

namespace RecordShopAPI.Tests;

public class ControllerTests
{
    Mock<IRecordsService> _mockService;
    RecordsController recordsController;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IRecordsService>();
        recordsController = new RecordsController(_mockService.Object);
    }

    #region GetAllRecords method tests
    [Test]
    public void GetAllRecords_ReturnsOkObjectResult()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllRecords()).Returns(expected);

        // Act
        var objectResult = recordsController.GetAllRecords();

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetAllRecords_ReturnsListOfRecordsType()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllRecords()).Returns(expected);

        // Act
        var objectResult = recordsController.GetAllRecords() as OkObjectResult;
        var result = objectResult!.Value as List<Record>;

        // Assert
        Assert.That(result, Is.TypeOf<List<Record>>());
    }

    [Test]
    public void GetAllRecords_CallsServiceMethodOnce()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllRecords()).Returns(expected);

        // Act
        recordsController.GetAllRecords();

        // Assert
        _mockService.Verify(mockService => mockService.GetAllRecords(), Times.Once());
    }

    [Test]
    public void GetAllRecords_ReturnsRetrievedRecords()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockService.Setup(mockService => mockService.GetAllRecords()).Returns(expected);

        // Act
        var objectResult = recordsController.GetAllRecords() as OkObjectResult;
        var result = objectResult!.Value as List<Record>;

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
    #endregion

    #region AddNewRecord method tests
    [Test]
    public void AddNewRecord_OnValidInput_ReturnsOkObjectResult()
    {
        // Arrange
        var inputRecord = new Record { Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        var expected = new Record
        {
            Id = 1,
            Album = inputRecord.Album,
            Artist = inputRecord.Artist,
            Composer = inputRecord.Composer,
            Genre = inputRecord.Genre,
            Year = inputRecord.Year
        };

        _mockService.Setup(mockService => mockService.AddNewRecord(inputRecord)).Returns(expected);

        // Act
        var objectResult = recordsController.AddNewRecord(inputRecord);

        // Assert
        Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void AddNewRecord_OnValidInput_ReturnsRecordWithId()
    {
        // Arrange
        var inputRecord = new Record { Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };

        var expected = new Record
        {
            Id = 1,
            Album = inputRecord.Album,
            Artist = inputRecord.Artist,
            Composer = inputRecord.Composer,
            Genre = inputRecord.Genre,
            Year = inputRecord.Year
        };

        _mockService.Setup(mockService => mockService.AddNewRecord(inputRecord)).Returns(expected);

        // Act
        var objectResult = recordsController.AddNewRecord(inputRecord) as OkObjectResult;
        var result = objectResult!.Value as Record;

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void AddNewRecord_OnInvalidInput_ReturnsBadRequestObjectResult()
    {
        // Arrange
        var inputRecord = new Record { Album = "Album1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        recordsController.ModelState.AddModelError("Artist", "The Artist field is required.");

        // Act
        var objectResult = recordsController.AddNewRecord(inputRecord) as BadRequestObjectResult;

        // Assert
        Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion
}
