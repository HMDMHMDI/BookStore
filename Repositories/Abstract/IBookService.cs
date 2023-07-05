using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract;

public interface IBookService
{
    bool Add(Book book);
    bool Delete(int id);
    bool Update(Book book);
    bool Save();
    Book FindById(int id);
    IEnumerable<Book> GetAll();
    
}