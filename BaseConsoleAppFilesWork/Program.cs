using BaseConsoleAppFilesWork.Entity;
using BaseConsoleAppFilesWork.Service.impl;

var bookRepo = new RepositoryImpl<Book>();
var bookService = new BookServiceImpl(bookRepo);

var userRepo = new RepositoryImpl<User>();
var usersService = new UserServiceImpl(userRepo, bookService);

// Добавление книги
bookService.AddBook(new Book { Id = 1, Title = "C# 10", Author = "Troelsen" });
bookService.AddBook(new Book { Id = 2, Title = "CLR via C#", Author = "Richter" });
bookService.AddBook(new Book { Id = 3, Title = "C++", Author = "Richter" });

// Добавление ползователей
usersService.AddUser(new User { Id = 1, Name = "Anton",Email = "anton@gmail.com" });
usersService.AddUser(new User { Id = 2, Name = "Denis",Email = "denis@gmail.com" });

// Сохранение книг в JSON
bookService.SaveBooksToJson("books.json");

// Обновление книги
Book updateBook = new Book { Id = 1, Title = "C# 12 (обновлено)", Author = "Troelsen" };
bookService.UpdateBook(updateBook);

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

Console.WriteLine("\nВывод всех пользователей");
foreach (var user in usersService.GetAllUsers())
{
    Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
}


Console.WriteLine("\nДобавление книги пользователю");
Console.WriteLine(usersService.IssueBookToUser(1,1));


Console.WriteLine("\nВывод первого пользователя");
var userWithBook = usersService.GetUserById(1);
if (userWithBook != null)
{
    Console.WriteLine($"{userWithBook.Id}: {userWithBook.Name} - {userWithBook.Email}:");
    foreach (var books in userWithBook.BorrowedBooks)
    {
        Console.WriteLine($"Book: {books.Id} - {books.Title} - {books.Author}");
    }
}

Console.WriteLine("\nУдаление пользователя");
Console.WriteLine(usersService.DeleteByIdUser(2));

var updatedUser = new User { Id = 1, Name = "Anton Anton", Email = "antonUpdate@gmail.com" };
usersService.UpdateUser(updatedUser);

Console.WriteLine("\nВывод всех пользователей после удаления");
foreach (var user in usersService.GetAllUsers())
{
    Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
}

//Загрузка книг из JSON
bookService.ReadBooksFromJson("books.json");
Console.WriteLine("Список книг:");
foreach (var b in bookService.GetAllBooks())
{
    Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");
}