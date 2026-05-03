using WebAPIDeploymentLab.Models;

namespace WebAPIDeploymentLab.Repos.Interface
{
    public interface IBookRrepos
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> AddAsync(Book book);
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> UpdateAsync(int id, Book book);
        Task<bool> DeleteAsync(int id);
    }
}
