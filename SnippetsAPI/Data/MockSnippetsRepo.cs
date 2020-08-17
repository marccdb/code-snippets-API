using SnippetsAPI.Models;
using System;
using System.Collections.Generic;

namespace SnippetsAPI.Data
{
    public class MockSnippetsRepo : ISnippetRepo
    {
        public void CreateSnippet(Snippet snippet)
        {
            throw new NotImplementedException();
        }

        public Snippet GetSnippetById(int id)
        {
            return new Snippet { Id = 1, HowTo = "Fix computers", Line = "Using tools", Platform = "Windows" };
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            return new List<Snippet>
            {
                new Snippet { Id = 1, HowTo = "Fix computers", Line = "Using tools", Platform = "Windows" },
                new Snippet { Id = 2, HowTo = "Bake a cake", Line = "Using tools", Platform = "Linux" },
                new Snippet { Id = 3, HowTo = "Fry an egg", Line = "Using tools", Platform = "Windows" }
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateSnippet(Snippet snippet)
        {
            throw new NotImplementedException();
        }
    }
}
