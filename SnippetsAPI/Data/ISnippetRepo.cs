using SnippetsAPI.Models;
using System.Collections.Generic;


namespace SnippetsAPI.Data
{
    public interface ISnippetRepo
    {
        IEnumerable<Snippet> GetSnippets();
        Snippet GetSnippetById(int id);

    }
}
