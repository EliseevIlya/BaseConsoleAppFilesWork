namespace BaseConsoleAppFilesWork.Entity;

public class User
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
}