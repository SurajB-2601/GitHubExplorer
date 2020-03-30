using GalaSoft.MvvmLight.Command;
using GitHubExplorer.Interfaces;
using GitHubExplorer.Models;
using GitHubExplorer.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GitHubExplorer.ViewModels
{
    [QueryProperty("UserName", "username")]
    public class UserRepositoriesPageViewModel : ViewModelBase
    {
        #region Private properties
        private IRepoHostingClient _repoHostClient;
        private IMapper _mapper;
        #endregion

        #region Properties
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; Notify(); }
        }

        private ObservableCollection<RepositoryViewModel> _repositoryList;

        public ObservableCollection<RepositoryViewModel> RepositoryList
        {
            get { return _repositoryList; }
            set { _repositoryList = value; Notify(); }
        }

        private string _searchStatusText;

        public string SearchStatusText
        {
            get { return _searchStatusText; }
            set { _searchStatusText = value; Notify(); }
        }
        #endregion
        public RelayCommand OnAppearingCommand { get; set; }

        #region CTOR
        public UserRepositoriesPageViewModel(IRepoHostingClient repohostingClient, IMapper mapper)
        {
            _repoHostClient = repohostingClient;
            _mapper = mapper;
            RepositoryList = new ObservableCollection<RepositoryViewModel>();
            OnAppearingCommand = new RelayCommand(async () => await HandleOnAppearing());

        }
        #endregion

        public async Task HandleOnAppearing()
        {
            RepositoryList.Clear();
            SearchStatusText = string.Format(AppResources.RepoPage_SearchInProgressString, UserName);
            IsLoaderRunning = true;
            try
            {
                Repository[] repos = await _repoHostClient.GetRepositoriesByUserNameAsync(UserName);
                if (repos == null || repos.Length == 0)
                {
                    SearchStatusText = string.Format(AppResources.RepoPage_ResultNotFoundString, UserName);
                }
                else
                {
                    SearchStatusText = string.Empty;
                    foreach (var repo in repos)
                    {
                        RepositoryList.Add(_mapper.MapRepoDTOToRepoViewModel(repo));
                    }
                }
            }
            finally
            {
                IsLoaderRunning = false;
            }
        }

    }
}
