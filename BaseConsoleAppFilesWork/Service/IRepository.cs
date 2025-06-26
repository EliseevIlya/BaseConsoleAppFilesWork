namespace BaseConsoleAppFilesWork.Service;

public interface IRepository<T> where T : class
{
    void Add(T item);
    void DeleteById(int id);
    T? GetById(int id);
    List<T> GetAll();
}