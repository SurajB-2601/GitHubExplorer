using GitHubExplorer.Models;
using GitHubExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Utils
{
    public class MapperUtil
    {
        public static UserViewModel MapUserDTOToUserViewModel(User user, UserViewModel userVM)
        {
            if (userVM == null)
                userVM = new UserViewModel();
            userVM.Name = user.name;
            userVM.ImageUrl = user.avatar_url;
            userVM.Bio = !string.IsNullOrWhiteSpace(user.bio) ? user.bio : Constants.NO_INFO_STRING;
            userVM.UserName = user.login;
            return userVM;
        }

        public static RepositoryViewModel MapRepoDTOToRepoViewModel(Repository repo, RepositoryViewModel repoVM)
        {
            if (repoVM == null)
                repoVM = new RepositoryViewModel();
            repoVM.Name = repo.name;
            repoVM.Description = !string.IsNullOrWhiteSpace(repo.description) ? repo.description : Constants.NO_INFO_STRING;
            repoVM.Repo_URL = repo.html_url;
            repoVM.Language = repo.language;
            repoVM.StargazersCount = repo.stargazers_count;
            repoVM.ForksCount = repo.forks_count;
            repoVM.RepoImageURL = "repologo.png";
            return repoVM;
        }
    }
}
