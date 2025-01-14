using RecordShopAPI.Classes;
using RecordShopAPI.DbContexts;

namespace RecordShopAPI.Repositories;

public interface IRecordsRepository
{
    List<Record> GetAllRecords();
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
}
