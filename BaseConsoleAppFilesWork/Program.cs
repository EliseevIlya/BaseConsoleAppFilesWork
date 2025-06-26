using BaseConsoleAppFilesWork.Entity;
using BaseConsoleAppFilesWork.Service.impl;

var bookRepo = new RepositoryImpl<Book>();
var bookService = new BookServiceImpl(bookRepo);

// Добавление книги
bookService.AddBook(new Book { Id = 1, Title = "C# 10", Author = "Troelsen" });
bookService.AddBook(new Book { Id = 2, Title = "CLR via C#", Author = "Richter" });

// Обновление книги
var book = bookService.GetBookById(1);
if (book != null)
{
    book.Title = "C# 12 (обновлено)";
    bookService.UpdateBook(book);
}

// Вывод всех книг
Console.WriteLine("Список книг:");
foreach (var b in bookService.GetAllBooks())
{
    Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");
}

// Удаление книги
bookService.DeleteBook(2);

Console.WriteLine("\nПосле удаления:");
foreach (var b in bookService.GetAllBooks())
{
    Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");
}