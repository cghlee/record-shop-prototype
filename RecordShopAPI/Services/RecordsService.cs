using RecordShopAPI.Classes;
using RecordShopAPI.Repositories;

namespace RecordShopAPI.Services;

public interface IRecordsService
{
    Record AddNewRecord(Record newRecord);
    List<Record> GetAllRecords();
}

public class RecordsService : IRecordsService
{
    private readonly IRecordsRepository _recordsRepository;
    public RecordsService(IRecordsRepository recordsRepository)
    {
        _recordsRepository = recordsRepository;
    }

    public List<Record> GetAllRecords()
    {
        List<Record> allRecords = _recordsRepository.GetAllRecords();
        return allRecords;
    }

    public Record AddNewRecord(Record newRecord)
    {
        Record recordWithIdAdded = _recordsRepository.AddNewRecord(newRecord);
        return recordWithIdAdded;
    }
}
