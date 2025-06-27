using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service;

public interface IUserService
{
    User? GetUserById(int id);
    List<User> GetAllUsers();
    User? UpdateUser(User user);
    string IssueBookToUser(int userId, int bookId);
    string DeleteByIdUser(int userId);
}