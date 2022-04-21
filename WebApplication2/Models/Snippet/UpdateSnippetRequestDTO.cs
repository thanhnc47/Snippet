using System.Text.Json.Serialization;

namespace WebApplication2.Models.Snippet
{
    public class UpdateSnippetRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}