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
    public void GetAllRecords_ReturnsListOfRecords()
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
}
