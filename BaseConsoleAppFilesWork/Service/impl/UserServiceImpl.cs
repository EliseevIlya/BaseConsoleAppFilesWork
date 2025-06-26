using BaseConsoleAppFilesWork.Entity;

namespace BaseConsoleAppFilesWork.Service.impl;

public class UserServiceImpl
{
    private readonly IRepository<User> _userRepository;

    public UserServiceImpl(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }
    
}