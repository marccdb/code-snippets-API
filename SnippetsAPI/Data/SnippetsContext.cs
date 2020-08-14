using Microsoft.EntityFrameworkCore;
using SnippetsAPI.Models;

namespace SnippetsAPI.Data
{
    public class SnippetsContext : DbContext
    {
        public SnippetsContext(DbContextOptions<SnippetsContext> options) : base (options)
        {

        }

        public DbSet<Snippet> Snippets { get; set; }
    }
}
