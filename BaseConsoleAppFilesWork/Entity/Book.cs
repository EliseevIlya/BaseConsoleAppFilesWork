namespace BaseConsoleAppFilesWork.Entity;

public class Book
{
    public int Id { get; init; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsAvailable { get; set; } = true;
}