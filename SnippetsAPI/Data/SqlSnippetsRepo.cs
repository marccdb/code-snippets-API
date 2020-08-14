using SnippetsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SnippetsAPI.Data
{
    public class SqlSnippetsRepo : ISnippetRepo
    {
        private readonly SnippetsContext _context;

        public SqlSnippetsRepo(SnippetsContext context)
        {
            _context = context;
        }




        public Snippet GetSnippetById(int id)
        {
            return _context.Snippets.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            return _context.Snippets.ToList();
        }
    }
}
