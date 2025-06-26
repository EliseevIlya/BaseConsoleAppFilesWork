using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service;

public interface IBookService
{
    public Book? GetBookById(List<Book?> books,int id);
    public List<Book> GetBooks(List<Book> books);
    public List<Book> AddBook(List<Book> books,Book book);
    public List<Book> UpdateBook(List<Book> books,Book book);
    public List<Book>  DeleteBook(List<Book> books,int id);
    public bool BookExists(List<Book> books,int id);
    public List<Book> SetBookStatus(List<Book> books,int id,bool status);
}