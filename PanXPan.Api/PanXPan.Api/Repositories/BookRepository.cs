using Marvin.JsonPatch;
using PanXPan.Api.Interfaces;
using PanXPan.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PanXPan.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContextFactory<PanXPanDbContext> _contextFactory;

        public BookRepository(IDbContextFactory<PanXPanDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<Book>> Get()
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Books.ToListAsync();
            }
        }

        public async Task<Book> GetById(Guid id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Books.FirstOrDefaultAsync(t => t.Id == id);
            }
        }

        public async Task<bool> Exists(Guid id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Books.AnyAsync(t => t.Id == id);
            }
        }

        public async Task<Book> Add(Book book)
        {
            using (var dbContext = _contextFactory.GetContext())
            {
                book.Id = Guid.NewGuid();
                book.CreateDate = DateTime.UtcNow;
                var addedTrade = dbContext.Books.Add(book);
                await dbContext.SaveChangesAsync();
                return await GetById(book.Id);
            }
        }

        public async Task Update(Guid id, Book book)
        {
            if (book == null || id == Guid.Empty) { throw new ArgumentNullException(nameof(id)); }

            using (var dbContext = _contextFactory.GetContext())
            {
                var targetBook = await dbContext.Books.FirstOrDefaultAsync(t => t.Id == id);
                if (targetBook == null)
                    throw new ArgumentNullException(nameof(targetBook));
                targetBook.UpdateDate = DateTime.UtcNow;
                targetBook.DateOfPublication = book.DateOfPublication;
                targetBook.Name = book.Name;
                targetBook.NumberOfPages = book.NumberOfPages;
                targetBook.Authors = book.Authors;
                dbContext.Books.Attach(targetBook);
                dbContext.Entry(targetBook).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Book> Patch(Guid id, JsonPatchDocument<Book> patchBook)
        {
            using (var dbContext = _contextFactory.GetContext())
            {
                var book = await dbContext.Books.FirstOrDefaultAsync(t => t.Id == id);
                patchBook.ApplyTo(book);
                book.UpdateDate = DateTime.UtcNow;
                dbContext.Books.Attach(book);
                dbContext.Entry(book).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return await GetById(id);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var context = _contextFactory.GetContext())
            {
                var itemToBeDeleted = await context.Books.FirstOrDefaultAsync(t => t.Id == id);
                if (itemToBeDeleted == null)
                    return await Task.FromResult(false);
                context.Entry(itemToBeDeleted).State = EntityState.Deleted;
                context.SaveChanges();
                return await Task.FromResult(true);
            }
        }
    }
}