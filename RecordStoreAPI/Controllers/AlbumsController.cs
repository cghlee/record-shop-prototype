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

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetAlbumById(int id)
    {
        Album? foundAlbum = _albumsService.FindAlbumById(id);

        if (foundAlbum == null)
            return BadRequest($"No database album exists with an ID of {id}.");

        return Ok(foundAlbum);
    }

    [HttpGet]
    [Route("Year")]
    public IActionResult GetAlbumsByYear(int year)
    {
        List<Album>? albumsFromYear = _albumsService.FindAlbumsByYear(year);

        if (albumsFromYear == null)
            return BadRequest($"No database album was released in the Year {year}.");

        return Ok(albumsFromYear);
    }

    [HttpPost]
    public IActionResult PostNewAlbum(Album newAlbum)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Album albumWithIdAdded = _albumsService.AddNewAlbum(newAlbum);
        return Ok(albumWithIdAdded);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult PutAlbumById(int id, Album albumToPut)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Album? updatedAlbum = _albumsService.UpdateAlbumById(id, albumToPut);

        if (updatedAlbum == null)
            return BadRequest($"No database album exists with an ID of {id}.");

        return Ok(updatedAlbum);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteAlbumById(int id)
    {
        Album? deletedAlbum = _albumsService.DeleteAlbumById(id);

        if (deletedAlbum == null)
            return BadRequest($"No database album exists with an ID of {id}.");

        return NoContent();
    }
}
