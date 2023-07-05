using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation;

public class AuthorService : IAuthorService
{
    private readonly DatabaseContext _context;

    public AuthorService(DatabaseContext context)
    {
        _context = context;
    }
    public bool Add(Author author)
    {
        _context.Add(author);
        return Save();
    }

    public bool Delete(int id)
    {
        var data = this.FindById(id);
        _context.Remove(data);
        return Save();
    }

    public bool Update(Author author)
    {
        _context.Authors.Update(author);
        return Save();
    }

    public Author FindById(int id)
    {
        return _context.Authors.Find(id);
    }

    public IEnumerable<Author> GetAll()
    {
        return _context.Authors.ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}