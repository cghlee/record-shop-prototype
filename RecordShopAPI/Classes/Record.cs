namespace RecordShopAPI.Classes;

public class Record
{
    public int Id { get; set; }
    public string Album { get; set; } = "";
    public string Artist { get; set; } = "";
    public string Composer { get; set; } = "";
    public string Genre { get; set; } = "";
    public int Year { get; set; }
}
