using Microsoft.EntityFrameworkCore;
using Moq;
using RecordShopAPI.Classes;
using RecordShopAPI.DbContexts;
using RecordShopAPI.Repositories;

namespace RecordShopAPI.Tests;

public class RepositoryTests
{
    RecordsDbContext _testDbContext;
    RecordsRepository recordsRepository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<RecordsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _testDbContext = new RecordsDbContext(options);

        recordsRepository = new RecordsRepository(_testDbContext);
    }

    [TearDown]
    public void Teardown()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }

    [Test]
    public void GetAllRecords_ReturnsListOfRecords()
    {
        // Arrange
        var expectedRecord = new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Records.Add(expectedRecord);
        _testDbContext.SaveChanges();

        var expectedList = new List<Record>
        {
            expectedRecord,
        };

        // Act
        var result = recordsRepository.GetAllRecords();

        // Assert
        Assert.That(result, Is.TypeOf<List<Record>>());
    }

    [Test]
    public void GetAllRecords_ReturnsRetrievedRecords()
    {
        // Arrange
        var expectedRecord = new Record { Id = 1, Album = "Album1", Artist = "Artist1", Composer = "Composer1", Genre = "Genre1", Year = 2001 };
        _testDbContext.Records.Add(expectedRecord);
        _testDbContext.SaveChanges();

        var expectedList = new List<Record>
        {
            expectedRecord,
        };

        // Act
        var result = recordsRepository.GetAllRecords();

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedList));
    }
}
