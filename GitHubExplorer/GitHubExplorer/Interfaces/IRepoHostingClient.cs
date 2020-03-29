using GitHubExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Interfaces
{
    public interface IRepoHostingClient
    {
        Task<User> GetUserInfoByUserName(string username);
        Task<Repository[]> GetRepositoriesByUserNameAsync(string username);
    }
}
