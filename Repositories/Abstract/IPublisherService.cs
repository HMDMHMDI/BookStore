using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract;

public interface IPublisherService
{
    bool Add(Publisher publisher);
    bool Delete(int id);
    bool Update(Publisher publisher);
    bool Save();
    Publisher FindById(int id);
    IEnumerable<Publisher> GetAll();
}