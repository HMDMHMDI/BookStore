using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation;

public class PublisherService: IPublisherService
{
    private readonly DatabaseContext _context;

    public PublisherService(DatabaseContext context)
    {
        _context = context;
    }
    public bool Add(Publisher publisher)
    {
        _context.Add(publisher);
        return Save();
    }

    public bool Delete(int id)
    {
        var data = this.FindById(id);
        _context.Remove(data);
        return Save();
    }

    public bool Update(Publisher publisher)
    {
        _context.Update(publisher);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public Publisher FindById(int id)
    {
        return _context.Publishers.Find(id);
    }

    public IEnumerable<Publisher> GetAll()
    {
        return _context.Publishers.ToList();
    }
}