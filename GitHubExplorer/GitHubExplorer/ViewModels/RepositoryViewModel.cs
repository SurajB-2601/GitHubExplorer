using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.ViewModels
{
    public class RepositoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Repo_URL { get; set; }
        public string Language { get; set; }
        public int StargazersCount { get; set; }
        public int ForksCount { get; set; }
    }
}
