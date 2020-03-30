using GitHubExplorer.Models;
using GitHubExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Interfaces
{
    public interface IMapper
    {
        UserViewModel MapUserDTOToUserViewModel(User user, UserViewModel userVM = null);
        RepositoryViewModel MapRepoDTOToRepoViewModel(Repository repo, RepositoryViewModel repoVM = null);
    }
}
