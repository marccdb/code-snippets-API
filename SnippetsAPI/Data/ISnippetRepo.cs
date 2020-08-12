using SnippetsAPI.Models;
using System.Collections.Generic;


namespace SnippetsAPI.Data
{
    interface ISnippetRepo
    {
        IEnumerable<Snippet> GetSnippets();
        Snippet GetSnippetById(int id);

    }
}
