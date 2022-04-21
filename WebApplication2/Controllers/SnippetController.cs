using Microsoft.AspNetCore.Mvc;
using WebApplication2.Filters.Snippet;
using WebApplication2.Models.Snippet;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnippetController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SnippetController> _logger;
        private readonly ISnippetService _snippetService;

        public SnippetController(
            ILogger<SnippetController> logger,
            ISnippetService snippetService)
        {
            _snippetService = snippetService;
            _logger = logger;
        }

        // [HttpGet("get")]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = Random.Shared.Next(-20, 55),
        //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        [HttpGet]
        public async Task<ActionResult<GetAllSnippetResponseDTO>> GetAllSnippets()
        {
            return Ok(await _snippetService.GetAllSnippets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSnippetByIdResponseDTO>> GetSnippetById(int id)
        {
            var data = await _snippetService.GetSnippetById(id);
            if (data is null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> AddSnippet(AddSnippetRequestDTO model)
        {
            await _snippetService.AddSnippet(model);
            return Ok();
        }

        [HttpPut("{id}")]
        // [CheckSnippetExistFilter]
        public async Task<ActionResult> UpdateSnippet(int id, UpdateSnippetRequestDTO model)
        {
            // var snippet = await _snippetService.GetSnippetById(id);
            // if (snippet is null)
            // {
            //     return BadRequest();
            // }
            await _snippetService.UpdateSnippet(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        // [CheckSnippetExistFilter]
        public async Task<ActionResult> DeleteSnippet(int id)
        {
            await _snippetService.DeleteSnippet(id);
            return Ok();
        }
    }
}