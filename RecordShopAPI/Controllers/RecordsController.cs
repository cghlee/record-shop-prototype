using Microsoft.AspNetCore.Mvc;
using RecordShopAPI.Classes;
using RecordShopAPI.Services;

namespace RecordShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RecordsController : ControllerBase
{
    private readonly IRecordsService _recordsService;
    public RecordsController(IRecordsService recordsService)
    {
        _recordsService = recordsService;
    }

    [HttpGet]
    public IActionResult GetAllRecords()
    {
        List<Record> allRecords = _recordsService.GetAllRecords();
        return Ok(allRecords);
    }

    [HttpPost]
    public IActionResult AddNewRecord(Record newRecord)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Record recordWithIdAdded = _recordsService.AddNewRecord(newRecord);
        return Ok(recordWithIdAdded);
    }
}
