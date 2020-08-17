using SnippetsAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnippetsAPI.Data
{
    public class SqlSnippetsRepo : ISnippetRepo
    {
        private readonly SnippetsContext _context;

        public SqlSnippetsRepo(SnippetsContext context)
        {
            _context = context;
        }

        public void CreateSnippet(Snippet snippet)
        {
            if (snippet == null)
            {
                throw new InvalidDataException("Please insert a valid snippet");
            }

            _context.Snippets.Add(snippet);
        }

        public void DeleteSnippet(Snippet snippet)
        {
            if (snippet == null)
            {
                throw new InvalidDataException("Please insert a valid snippet");
            }
            _context.Snippets.Remove(snippet);

        }

        public Snippet GetSnippetById(int id)
        {
            return _context.Snippets.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            return _context.Snippets.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSnippet(Snippet snippet)
        {
            //Handled by EF
        }
    }
}
