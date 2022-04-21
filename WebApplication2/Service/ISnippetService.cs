using WebApplication2.Models.Snippet;

namespace WebApplication2.Service
{
    public interface ISnippetService
    {
        Task<List<GetAllSnippetResponseDTO>> GetAllSnippets();
        Task<GetSnippetByIdResponseDTO> GetSnippetById(int id);
        Task AddSnippet(AddSnippetRequestDTO model);
        Task UpdateSnippet(int id, UpdateSnippetRequestDTO model);
        Task DeleteSnippet(int id);
    }
}