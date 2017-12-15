using AutoMapper;
using PanXPan.Api.Models;
using PanXPan.Api.Representations;

namespace PanXPan.Api.Mappings
{
    public class ModelsMapProfile : Profile
    {
        public ModelsMapProfile()
        {
            #region Trade Mappings

            CreateMap<Book, BookRepresentation>()
                .ForMember(x => x.Authors, y => y.MapFrom(p => p.Authors.Split(new[] { ',' })))
                .ReverseMap()
                .ForMember(x => x.Authors, y => y.MapFrom(p => string.Join(",", p.Authors)))
                .ForMember(x => x.CreateDate, opt => opt.Ignore())
                .ForMember(x => x.UpdateDate, opt => opt.Ignore());

            #endregion
        }
    }
}