namespace BaseConsoleAppFilesWork.Service.impl;

public class RepositoryImpl<T> : IRepository<T> where T : class 
{
    protected readonly List<T> Items = new();

    public void Add(T item)
    {
        Items.Add(item);
    }

    public void DeleteById(int id)
    {
        var item = GetById(id);
        if (item != null) Items.Remove(item);
    }

    public T? GetById(int id)
    {
        return Items.FirstOrDefault(item => GetId(item).Equals(id));
    }

    public List<T> GetAll()
    {
        return Items;
    }
    
    protected virtual int GetId(T item)
    {
        var prop = typeof(T).GetProperty("Id");
        return prop != null ? (int)(prop.GetValue(item) ?? 0) : 0;
    }
}