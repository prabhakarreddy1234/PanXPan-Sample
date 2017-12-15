using Marvin.JsonPatch;
using PanXPan.Api.Models;
using PanXPan.Api.Representations;
using System.Collections.Generic;

namespace PanXPan.Api.Mappings
{
    public static class AutoMapperExtensions
    {
        public static Book ToEntity(this BookRepresentation trade, Book dest = null)
        {
            return AutoMapperConfiguration.ToEntity(trade, dest);
        }

        public static JsonPatchDocument<Book> ToEntity(this JsonPatchDocument<BookRepresentation> trade, JsonPatchDocument<Book> dest = null)
        {
            return AutoMapperConfiguration.ToEntity(trade, dest);
        }

        public static BookRepresentation ToRepresentation(this Book trade)
        {
            return AutoMapperConfiguration.ToRepresentation(trade);
        }

        public static ICollection<BookRepresentation> ToRepresentation(this ICollection<Book> books)
        {
            return AutoMapperConfiguration.ToRepresentation(books);
        }
    }
}