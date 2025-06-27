using System.Text.Json;
using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service.impl;

public class BookServiceImpl : IBookService
{
    private readonly IRepository<Book> _repository;

    public BookServiceImpl(IRepository<Book> repository)
    {
        _repository = repository;
    }


    public Book? GetBookById(int id)
    {
        return _repository.GetById(id);
    }

    public List<Book> GetAllBooks()
    {
        return _repository.GetAll();
    }

    public List<Book> AddBook(Book book)
    {
        _repository.Add(book);
        return _repository.GetAll();
    }

    public List<Book> UpdateBook(Book updatedBook)
    {
        var existingBook = _repository.GetById(updatedBook.Id);
        if (existingBook == null)
        {
            Console.WriteLine("Book not found");
            return _repository.GetAll();
        }
       
        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Description = updatedBook.Description;
        existingBook.IsAvailable = updatedBook.IsAvailable;
        return _repository.GetAll();
    }

    public List<Book> DeleteBook(int id)
    {
        _repository.DeleteById(id);
        return _repository.GetAll();
    }

    public bool BookExists(int id)
    {
        var book = _repository.GetById(id);
        return book is { IsAvailable: true };
    }

    public List<Book> SetBookStatus(int id, bool status)
    {   
        var book = _repository.GetById(id);
        if (book != null)
        {
            book.IsAvailable = status;
        }
        return _repository.GetAll();
    }

    public void SaveBooksToJson(string filePath)
    {
        List<Book> books = _repository.GetAll();
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(books, options);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Books saved to {filePath}");
    }

    public void ReadBooksFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found");
            return;
        }
        string json = File.ReadAllText(filePath);
        var loadedBooks = JsonSerializer.Deserialize<List<Book>>(json);
        if (loadedBooks == null)
        {
            Console.WriteLine("No Books");
            return;
        }

        foreach (var book in loadedBooks)
        {
            if (_repository.GetById(book.Id) == null)
            {
                _repository.Add(book);
                
            }
        }

        Console.WriteLine($"Books loaded from {filePath}");
    }
}