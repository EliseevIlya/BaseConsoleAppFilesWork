using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service.impl;

public class BookServiceImpl : IBookService
{
    public Book? GetBookById(List<Book?> books, int id)
    {
        return books.FirstOrDefault(b => b != null && b.BookId == id);
    }

    public List<Book> GetBooks(List<Book> books)
    {
        return books;
    }

    public List<Book> AddBook(List<Book> books, Book book)
    {
        books.Add(book);
        return books;
    }

    public List<Book> UpdateBook(List<Book> books, Book book)
    {
        var existingBook = books.FirstOrDefault(b => b.BookId == book.BookId);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.IsAvailable = book.IsAvailable;
        }
        return books;
    }

    public List<Book> DeleteBook(List<Book> books, int id)
    {
        books.Remove(books.FirstOrDefault(b => b.BookId == id));
        return books;
    }

    public bool BookExists(List<Book> books, int id)
    {
        var book = books.FirstOrDefault(b => b.BookId == id);
        return book is { IsAvailable: true };
    }

    public List<Book> SetBookStatus(List<Book> books, int id, bool status)
    {   
        var book = books.FirstOrDefault(b => b.BookId == id);
        if (book != null)
        {
            book.IsAvailable = status;
        }
        return books;
    }
}