
using AutoMapper;
using Marvin.JsonPatch;
using PanXPan.Api.Models;
using PanXPan.Api.Representations;
using System.Collections.Generic;

namespace PanXPan.Api.Mappings
{
    public class AutoMapperConfiguration
    {
        public static IMapper MapperInstance { get; set; }

        static AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ModelsMapProfile>(); });

            MapperInstance = config.CreateMapper();

            config.AssertConfigurationIsValid();
        }

        public static Book ToEntity(BookRepresentation representation, Book dest = null)
        {
            return representation == null ? null : MapperInstance.Map(representation, dest);
        }

        public static JsonPatchDocument<Book> ToEntity(JsonPatchDocument<BookRepresentation> representation, JsonPatchDocument<Book> dest = null)
        {
            return representation == null ? null : MapperInstance.Map(representation, dest);
        }

        public static BookRepresentation ToRepresentation(Book trade)
        {
            return trade == null ? null : MapperInstance.Map<Book, BookRepresentation>(trade);
        }


        public static ICollection<BookRepresentation> ToRepresentation(ICollection<Book> trades)
        {
            return MapperInstance.Map<ICollection<Book>, ICollection<BookRepresentation>>(trades);
        }
    }
}