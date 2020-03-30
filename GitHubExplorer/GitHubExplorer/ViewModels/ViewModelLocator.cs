using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GitHubExplorer.Helpers;
using GitHubExplorer.Interfaces;
using GitHubExplorer.Models;
using GitHubExplorer.Utils;
using System;
using Xamarin.Forms;

namespace GitHubExplorer.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<UserRepositoriesPageViewModel>();
            SimpleIoc.Default.Register<IRepoHostingClient, GitHubClientHelper>(createInstanceImmediately: false);
            SimpleIoc.Default.Register<IMapper, MapperUtil>(createInstanceImmediately: false);
            SimpleIoc.Default.Register<ILogger>(() => DependencyService.Get<ILogManager>().GetLog(), createInstanceImmediately: false);
        }

        public HomePageViewModel HomePage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }

        public UserRepositoriesPageViewModel UserRepositoriesPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserRepositoriesPageViewModel>();
            }
        }
    }
}
