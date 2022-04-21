using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Snippet
{
    public class AddSnippetRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}