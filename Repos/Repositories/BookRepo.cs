using Microsoft.EntityFrameworkCore;
using WebAPIDeploymentLab.Data;
using WebAPIDeploymentLab.Models;
using WebAPIDeploymentLab.Repos.Interface;

namespace WebAPIDeploymentLab.Repos.Repositories
{
    public class BookRepo : IBookRrepos
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }    

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;           

            await _context.SaveChangesAsync();
            return existingBook;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return false;
            }

            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

