using labrab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace labrab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionsController : ControllerBase, IDisposable
    {
        private readonly AppDbContext context;
        public CompositionsController(AppDbContext _context)
        {
            this.context = _context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
        /// <summary>
        /// Get all compositions
        /// GET: api/&lt;CompositionsController&gt;/List
        /// </summary>
        /// <returns>List of all compositions</returns>
        [HttpGet("List")]
        public IAsyncEnumerable<Composition> Get()
        {
            return context.Compositions.AsAsyncEnumerable();
        }

        /// <summary>
        /// Search for compositions by name or composer
        /// GET api/&lt;CompositionsController&gt;/Search
        /// </summary>
        /// <param name="query">Search param</param>
        /// <returns>Fitlered compositions</returns>
        [HttpGet("Search")]
        public IAsyncEnumerable<Composition> Search(string query)
        {
            return context.Compositions
                .Where((composition) => composition.Name == query || composition.Composer == query)
                .AsAsyncEnumerable();
        }
        /// <summary>
        /// Add composition by name and composer
        /// POST api/&lt;CompositionsController&gt;/Add
        /// </summary>
        /// <param name="value">Object to Add</param>
        [HttpPost("Add")]
        async public void Add([FromBody] Composition value)
        {
            await context.Compositions.AddAsync(value);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove composition by name and composer
        /// PUT api/&lt;CompositionsController&gt;/Del
        /// </summary>
        /// <param name="value">Composition to remove</param>
        [HttpDelete("Del")]
        async public void Delete([FromBody] Composition value)
        {
            context.Compositions.Remove(value);
            await context.SaveChangesAsync();
        }
    }
}
