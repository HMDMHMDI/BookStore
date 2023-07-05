using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation;

public class BookService : IBookService
{
    private readonly DatabaseContext _context;

    public BookService(DatabaseContext context)
    {
        _context = context;
    }
    public bool Add(Book book)
    {
        _context.Books.Add(book);
        return Save();
    }

    public bool Delete(int id)
    {
        var data = this.FindById(id);
        _context.Books.Remove(data);
        return Save();
    }

    public bool Update(Book book)
    {
        _context.Books.Update(book);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public Book FindById(int id)
    {
        return _context.Books.Find(id);
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Books.ToList();
    }
}