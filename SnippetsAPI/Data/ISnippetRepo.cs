using SnippetsAPI.Models;
using System.Collections.Generic;


namespace SnippetsAPI.Data
{
    public interface ISnippetRepo
    {
        bool SaveChanges();

        IEnumerable<Snippet> GetSnippets();
        Snippet GetSnippetById(int id);
        void CreateSnippet(Snippet snippet);

        void UpdateSnippet(Snippet snippet);

    }
}
