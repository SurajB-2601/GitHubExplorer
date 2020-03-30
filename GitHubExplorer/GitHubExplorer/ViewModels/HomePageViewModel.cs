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
    public class HomePageViewModel: ViewModelBase
    {
        #region private members
        private IRepoHostingClient _repoHostClient;
        private IMapper _mapper;
        private ILogger _logger;
        #endregion

        #region properties
        private ObservableCollection<UserViewModel> _userList;

        public ObservableCollection<UserViewModel> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                Notify();
            }
        }

        private string _searchStatusText;

        public string SearchStatusText
        {
            get { return _searchStatusText; }
            set { _searchStatusText = value; Notify(); }
        }

        private string _clickableText = string.Empty;

        public string ClickableText
        {
            get { return _clickableText; }
            set { _clickableText = value; Notify(); }
        }

        #endregion

        #region Command Object Declarations

        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand ClickableTextCommand { get; set; }
        public RelayCommand<UserViewModel> UserSelectionChangeCommand { get; set; }

        #endregion

        #region CTOR
        public HomePageViewModel(IRepoHostingClient repoHostClient, IMapper mapper, ILogger logger)
        {
            SearchCommand = new RelayCommand<string>(async param => await ExecuteUserSearch(param));
            ClickableTextCommand = new RelayCommand(async () => await ExecuteClickableTextTap());
            UserSelectionChangeCommand = new RelayCommand<UserViewModel>(async param => await ExecuteUserSelection(param));

            UserList = new ObservableCollection<UserViewModel>();
            this._repoHostClient = repoHostClient;
            this._mapper = mapper;
            _logger = logger;
            SearchStatusText = AppResources.HomePage_InitiailSearchString;
            ClickableText = AppResources.Sample_User;

        }
        #endregion

        #region Methods
        public async Task ExecuteClickableTextTap()
        {
            SearchStatusText = ClickableText;
            ClickableText = string.Empty;
            await ExecuteUserSearch(SearchStatusText);
        }

        public async Task ExecuteUserSearch(string searchQuery)
        {
            UserList.Clear();
            SearchStatusText = string.Format(AppResources.HomePage_SearchInProgressString, searchQuery);
            ClickableText = string.Empty;
            IsLoaderRunning = true;
            try
            {
                User searchedUser = await _repoHostClient.GetUserInfoByUserName(searchQuery);
                if (searchedUser == null)
                {
                    SearchStatusText = string.Format(AppResources.HomePage_ResultNotFoundString, searchQuery);
                    ClickableText = AppResources.Sample_User;
                }
                else
                {
                    SearchStatusText = string.Empty;
                    UserList.Add(_mapper.MapUserDTOToUserViewModel(searchedUser));
                }
            }
            finally
            {
                IsLoaderRunning = false;
            }
        }

        public async Task ExecuteUserSelection(UserViewModel selectedUser)
        {
            await Shell.Current.GoToAsync($"userrepos?username={selectedUser.UserName}");
        }
        #endregion
    }
}
