using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service.impl;

public class UserServiceImpl : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IBookService _bookServiceImpl;

    public UserServiceImpl(IRepository<User> userRepository, BookServiceImpl bookServiceImpl)
    {
        _userRepository = userRepository;
        _bookServiceImpl = bookServiceImpl;
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public User? UpdateUser(User user)
    {
        User? userToUpdate = _userRepository.GetById(user.Id);
        if (userToUpdate != null)
        {
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            
        }
        return userToUpdate;

    }

    public string IssueBookToUser(int userId, int bookId)
    {
        User? user = _userRepository.GetById(userId);
        if (user == null) return $"User with id: {userId} not found";
        
        Book? book = _bookServiceImpl.GetBookById(bookId);
        if (book == null) return $"Book with id: {bookId} not found";
        
        if (!book.IsAvailable) return $"Book with id: {bookId} not available";
        
        _bookServiceImpl.SetBookStatus(bookId,false);
        user.BorrowedBooks.Add(book);
        return $"Book with id: {bookId} has been borrowed to user {user.Name}";
    }

    public string DeleteByIdUser(int userId)
    {
        User? user = _userRepository.GetById(userId);
        if (user == null) return $"User with id: {userId} not found";
        _userRepository.DeleteById(user.Id);
        return $"User with id: {userId} has been deleted";
    }
}