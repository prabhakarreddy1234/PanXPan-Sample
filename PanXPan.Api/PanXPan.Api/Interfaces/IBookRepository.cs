using Marvin.JsonPatch;
using PanXPan.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanXPan.Api.Interfaces
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> Get();

        Task<Book> GetById(Guid id);

        Task<Book> Add(Book trade);

        Task Update(Guid id, Book trade);

        Task<Book> Patch(Guid id, JsonPatchDocument<Book> patchTrade);

        Task<bool> Delete(Guid id);

        Task<bool> Exists(Guid id);
    }
}
