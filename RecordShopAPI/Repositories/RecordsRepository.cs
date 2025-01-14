using RecordShopAPI.Classes;
using RecordShopAPI.DbContexts;

namespace RecordShopAPI.Repositories;

public interface IRecordsRepository
{
    List<Record> GetAllRecords();
    Record AddNewRecord(Record newRecord);
}

public class RecordsRepository : IRecordsRepository
{
    private readonly RecordsDbContext _recordsDbContext;
    public RecordsRepository(RecordsDbContext recordsDbContext)
    {
        _recordsDbContext = recordsDbContext;
    }

    public List<Record> GetAllRecords()
    {
        List<Record> allRecords = _recordsDbContext.Records.ToList();
        return allRecords;
    }

    public Record AddNewRecord(Record newRecord)
    {
        _recordsDbContext.Records.Add(newRecord);
        _recordsDbContext.SaveChanges();
        return newRecord;
    }
}
