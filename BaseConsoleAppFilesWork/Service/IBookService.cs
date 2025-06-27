using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service;

public interface IBookService
{
    public Book? GetBookById(int id);
    public List<Book> GetAllBooks();
    public List<Book> AddBook(Book book);
    public List<Book> UpdateBook(Book updatedBook);
    public List<Book>  DeleteBook(int id);
    public bool BookExists(int id);
    public List<Book> SetBookStatus(int id,bool status);
    void SaveBooksToJson(string filePath);
    void ReadBooksFromJson(string filePath);
}