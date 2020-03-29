using GitHubExplorer.Interfaces;
using GitHubExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Helpers
{
    /// <summary>
    /// A client API Helper for the GitLab Repository Hosting client.
    /// Note: This class is kept for future reference and is not implemented!
    /// </summary>
    class GitLabClientHelper : IRepoHostingClient
    {
        public Task<Repository[]> GetRepositoriesByUserNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserInfoByUserName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
