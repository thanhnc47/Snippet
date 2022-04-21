using AutoMapper;
using WebApplication2.DataAccess;
using WebApplication2.Models.Snippet;

namespace WebApplication2.Models
{
    public class MappingProfile : Profile {
     public MappingProfile() {
         // Add as many of these lines as you need to map your objects
        CreateMap<SnippetEntity, GetAllSnippetResponseDTO>();
        CreateMap<SnippetEntity, GetSnippetByIdResponseDTO>();
        CreateMap<AddSnippetRequestDTO, SnippetEntity>();
        CreateMap<UpdateSnippetRequestDTO, SnippetEntity>();
        
     }
 }
}