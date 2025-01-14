using Moq;
using RecordShopAPI.Classes;
using RecordShopAPI.Repositories;
using RecordShopAPI.Services;

namespace RecordShopAPI.Tests;

public class ServiceTests
{
    Mock<IRecordsRepository> _mockRepository;
    RecordsService recordsService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IRecordsRepository>();
        recordsService = new RecordsService(_mockRepository.Object);
    }

    #region GetAllRecords method tests
    [Test]
    public void GetAllRecords_ReturnsListOfRecordsType()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllRecords()).Returns(expected);

        // Act
        var result = recordsService.GetAllRecords();

        // Assert
        Assert.That(result, Is.TypeOf<List<Record>>());
    }

    [Test]
    public void GetAllRecords_CallsRepositoryMethodOnce()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllRecords()).Returns(expected);

        // Act
        recordsService.GetAllRecords();

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.GetAllRecords(), Times.Once());
    }

    [Test]
    public void GetAllRecords_ReturnsRetrievedRecords()
    {
        // Arrange
        var expected = new List<Record>
        {
            new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 },
        };

        _mockRepository.Setup(mockRepository => mockRepository.GetAllRecords()).Returns(expected);

        // Act
        var result = recordsService.GetAllRecords();

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
    #endregion

    #region AddNewRecord method tests
    [Test]
    public void AddNewRecord_ReturnsRecordType()
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewRecord(inputRecord)).Returns(expected);

        // Act
        var result = recordsService.AddNewRecord(inputRecord);

        // Assert
        Assert.That(result, Is.TypeOf<Record>());
    }

    [Test]
    public void AddNewRecord_CallsRespositoryMethodOnce()
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewRecord(inputRecord)).Returns(expected);

        // Act
        recordsService.AddNewRecord(inputRecord);

        // Assert
        _mockRepository.Verify(mockRepository => mockRepository.AddNewRecord(inputRecord), Times.Once());
    }

    [Test]
    public void AddNewRecord_ReturnsRecordWithId()
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

        _mockRepository.Setup(mockRepository => mockRepository.AddNewRecord(inputRecord)).Returns(expected);

        // Act
        var result = recordsService.AddNewRecord(inputRecord);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion
}
