using System.ComponentModel.DataAnnotations;

namespace RecordShopAPI.Classes;

public class Record
{
    public int Id { get; set; }

    [Required]
    public string Album { get; set; } = "";

    [Required]
    public string Artist { get; set; } = "";

    [Required]
    public string Composer { get; set; } = "";

    [Required]
    public string Genre { get; set; } = "";

    [Required]
    public int Year { get; set; }
}
