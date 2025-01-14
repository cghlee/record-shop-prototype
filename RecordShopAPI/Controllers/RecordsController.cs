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
}
