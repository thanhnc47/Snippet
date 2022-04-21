using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess;
using WebApplication2.Models.Snippet;

namespace WebApplication2.Service
{
    public class SnippetService : ISnippetService
    {
        private readonly SnippetContext _context;
        public SnippetService(SnippetContext context)
        {
            _context = context;
        }

        public Task AddSnippet(AddSnippetRequestDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSnippet(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllSnippetResponseDTO>> GetAllSnippets()
        {
            return await _context.Snippets.ProjectToListAsync<GetAllSnippetResponseDTO>();
        }

        public async Task<GetSnippetByIdResponseDTO> GetSnippetById(int id)
        {
            var a =  _context.Snippets.ProjectToFirst<GetSnippetByIdResponseDTO>();
            return await _context.Snippets.ProjectToFirstOrDefaultAsync<GetSnippetByIdResponseDTO>();
        }

        public Task UpdateSnippet(int id, UpdateSnippetRequestDTO model)
        {
            throw new NotImplementedException();
        }
    }
}