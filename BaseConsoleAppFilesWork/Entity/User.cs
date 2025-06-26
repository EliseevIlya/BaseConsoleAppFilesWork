namespace BaseConsoleAppFilesWork.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    private List<Book> BorrowedBools { get; set; } = new List<Book>();
}