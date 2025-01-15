using System.ComponentModel.DataAnnotations;

namespace RecordStoreAPI.Classes;

public class Album
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string Artist { get; set; } = "";

    [Required]
    public string Composer { get; set; } = "";

    [Required]
    public Genre Genre { get; set; }

    [Required]
    public int Year { get; set; }
}
