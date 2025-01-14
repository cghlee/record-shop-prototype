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

    #region GetAllRecords method tests
    [Test]
    public void GetAllRecords_ReturnsListOfRecordsType()
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

        // Act
        var result = recordsRepository.AddNewRecord(inputRecord);

        // Assert
        Assert.That(result, Is.TypeOf<Record>());
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

        // Act
        var result = recordsRepository.AddNewRecord(inputRecord);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expected.Id));
            Assert.That(result.Album, Is.EqualTo(expected.Album));
            Assert.That(result.Artist, Is.EqualTo(expected.Artist));
            Assert.That(result.Composer, Is.EqualTo(expected.Composer));
            Assert.That(result.Genre, Is.EqualTo(expected.Genre));
            Assert.That(result.Year, Is.EqualTo(expected.Year));
        });
    }
    #endregion
}
