using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Implementation;

public class GenreService : IGenreService
{
    private readonly DatabaseContext _context;

    public GenreService(DatabaseContext context)
    {
        _context = context;
    }
    public bool Add(Genre model)
    {
        _context.Add(model);
        return Save();
    }

    public bool Update(Genre model)
    {
        _context.Update(model);
        return Save();
    }

    public bool Delete(int id)
    {
        var data = this.FindById(id);
        _context.Remove(data);
        return Save();
    }

    public Genre FindById(int id)
    {
        return _context.Genres.Find(id);
    }

    public IEnumerable<Genre> GetAll()
    {
        return _context.Genres.ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}