using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract;

public interface IAuthorService
{
    bool Add(Author author);
    bool Delete(int id);
    bool Update(Author author);
    Author FindById(int id);
    IEnumerable<Author> GetAll();
    bool Save();
}