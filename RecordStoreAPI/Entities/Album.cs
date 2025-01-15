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
    [EnumDataType(typeof(Genre), ErrorMessage = "The Genre field is missing, or invalid Genre entered.")]
    public Genre Genre { get; set; }

    [Required]
    [Range(1850, 2100, ErrorMessage = "The Year field is missing, or invalid Year entered.")]
    public int Year { get; set; }
}
