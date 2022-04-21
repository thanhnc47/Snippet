using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataAccess;
using WebApplication2.Models.Snippet;

namespace WebApplication2.Service
{
    public class SnippetService : ISnippetService
    {
        private readonly SnippetContext _context;
        private readonly IMapper _mapper;

        public SnippetService(SnippetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddSnippet(AddSnippetRequestDTO model)
        {
            var snippet = _mapper.Map<SnippetEntity>(model);
            _context.Snippets.Add(snippet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSnippet(int id, UpdateSnippetRequestDTO model)
        {
            var snippet = new SnippetEntity { Id = id };
            _context.Attach(snippet);
            snippet.Title = model.Title;
            snippet.Content = model.Content;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSnippet(int id)
        {
            var snippet = new SnippetEntity { Id = id };
            _context.Attach(snippet);
            snippet.IsDeleted = 1;
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAllSnippetResponseDTO>> GetAllSnippets()
        {
            var data = await _context.Snippets.Where(p => p.IsDeleted == 0).ToListAsync();
            return _mapper.Map<List<GetAllSnippetResponseDTO>>(data);
        }

        public async Task<GetSnippetByIdResponseDTO> GetSnippetById(int id)
        {
            var data = await _context.Snippets.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == 0);
            return _mapper.Map<GetSnippetByIdResponseDTO>(data);
        }

        
    }
}