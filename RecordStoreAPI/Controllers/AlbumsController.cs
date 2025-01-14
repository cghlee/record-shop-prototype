using Microsoft.AspNetCore.Mvc;
using RecordStoreAPI.Classes;
using RecordStoreAPI.Services;

namespace RecordStoreAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumsService _albumsService;
    public AlbumsController(IAlbumsService albumsService)
    {
        _albumsService = albumsService;
    }

    [HttpGet]
    public IActionResult GetAllAlbums()
    {
        List<Album> allAlbums = _albumsService.GetAllAlbums();
        return Ok(allAlbums);
    }

    [HttpPost]
    public IActionResult PostNewAlbum(Album newAlbum)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Album albumWithIdAdded = _albumsService.AddNewAlbum(newAlbum);
        return Ok(albumWithIdAdded);
    }
}
